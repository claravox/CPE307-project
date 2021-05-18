using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.DnnModule;
using OpenCVForUnity.UnityUtils;
using Rect = OpenCVForUnity.CoreModule.Rect;


public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    //CascadeClassifier cascade;

    Net classifier;

    public bool live = true;
    public int resWidth = 2550;
    public int resHeight = 3300;

    bool onAndroid { get { return Application.platform == RuntimePlatform.Android; } }
    bool onIOS { get { return Application.platform == RuntimePlatform.IPhonePlayer; } }
    bool onMobile { get { return onAndroid || onIOS; } }

    const string prototxtFileName = "deploy.prototxt.txt";
    const string caffeModelFileName = "res10_300x300_ssd_iter_140000_fp16.caffemodel";

    string getWeightsDataPath()
    {
        if (!onMobile)
        {
            return Application.streamingAssetsPath;
        }

        //TODO: update code for android to download both
        // res10_300x300_ssd_iter_140000_fp16.caffemodel
        // and deploy.prototxt.txt to accessible location

        string url = Path.Combine(Application.streamingAssetsPath, "haarcascade_frontalface_default.xml");
        Debug.Log(string.Format("SecurityAR: url: {0}", url));
       
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            var task = request.SendWebRequest();
            while (!task.isDone)
            {
            }

            if (task.webRequest.isNetworkError || task.webRequest.isHttpError)
            {
                Debug.Log("SecurityAR: Failed to fetch asset file!");
                throw new Exception(string.Format("SecurityAR: Failed to fetch asset file {0}", task.webRequest.error.ToString()));
            }

            var text = task.webRequest.downloadHandler.text;

            string targetPath = Path.Combine(Application.persistentDataPath, "haarcascade_frontalface_default.xml");
            if (!File.Exists(targetPath))
            {
                File.WriteAllText(targetPath, text);
            }

            return targetPath;
        }
    }

            // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamDevice camera;


        //No device is availble
        if (devices.Length == 0)
        {
            Debug.Log("There is no camera device availble");
            this.enabled = false;
            return;
        }

        float width;
        float height;
        

        if (onMobile && devices.Length > 1)
        {
            camera = devices[1];
        }
        else
        {
            camera = devices[0];
        }

   
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
        
      
        Debug.Log("width = " + width);
        Debug.Log("height = " + height);

        _webCamTexture = new WebCamTexture(camera.name, (int)width, (int)height, 60);

        _webCamTexture.Play();
        Debug.Log("webcam width = " + _webCamTexture.width);
        Debug.Log("webcam height = " + _webCamTexture.height);

        string weightsRoot = getWeightsDataPath();
        classifier = Dnn.readNetFromCaffe(Path.Combine(weightsRoot, prototxtFileName),
            Path.Combine(weightsRoot, caffeModelFileName));
    }
    

    private Size kernelDimensions(int width, int height) => new Size( (width / 7) | 1, (height / 7) | 1);

    private int rectArea(Rect rect) => rect.width * rect.height;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(string.Format("classifier: {0}", classifier));
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);

        Mat frame = new Mat(_webCamTexture.height, _webCamTexture.width, CvType.CV_8UC4, new Scalar(0, 0, 0, 255));
        //Use OpenCV to find face _webCamTexture
        Color32[] colors = new Color32[_webCamTexture.width * _webCamTexture.height];
        Utils.webCamTextureToMat(_webCamTexture, frame, colors);

        /*
        if (onMobile)
        {
            frame.Rotate(RotateFlags.Rotate90Clockwise);
        }*/

        int width = frame.width();
        int height = frame.height();

        Rect[] maybeFaces = findNewfaces(frame, colors);
        if (maybeFaces.Length <= 0)
        {
            Debug.Log("No faces detected");
            return;
        }

        Rect face = maybeFaces[0];

        Debug.Log(string.Format("Detected Face At: ({0}, {1}) width={2} height={3}",
            face.x, face.y, face.width, face.height));

        /*Array.Sort(maybeFaces, (Rect r1, Rect r2) =>
            rectArea(r2).CompareTo(rectArea(r1)));

        int[] areas = new int[maybeFaces.Length];

        for (int i = 0; i < maybeFaces.Length; i++)
        {
            areas[i] = rectArea(maybeFaces[i]);
        }

        // currently, printing the sorted rectangle areas for debug purposes
        Debug.Log(string.Format("{0}", string.Join(",", areas)));
        
        for (int i = 1; i < maybeFaces.Length; i++)
		{
            OpenCvSharp.Rect face = maybeFaces[i];
            Mat subFrame = frame
                .ColRange(face.Location.X, face.Location.X + face.Width)
                .RowRange(face.Location.Y, face.Location.Y + face.Height);
            blurFace(subFrame);
		}*/

        if (live)
        {
             display(frame, maybeFaces, new Scalar(250, 0, 0));
        }
    }

    /*
    Mat spliceImage(Mat fullFrame, OpenCvSharp.Rect portion, Mat filler)
    {
        Mat target = fullFrame
            .ColRange(portion.Location.X, portion.Location.X + portion.Width)
            .RowRange(portion.Location.Y, portion.Location.Y + portion.Height);

        filler.CopyTo(target);

        return fullFrame;
    }*/

    Rect[] findNewfaces(Mat frame, Color32[] colors)
    {
        //Use this to do multi-face tracking
        Mat blob = Dnn.blobFromImage(frame, 1.0, new Size(frame.width(), frame.height()), new Scalar(104.0, 177.0, 123.0));

        //Debug.Log(string.Format("blob: {0}", blob));
        classifier.setInput(blob);
        Debug.Log(string.Format("classifier 2: {0}", classifier));
        Mat netOutput = classifier.forward();

        Core.MinMaxLocResult minmax = Core.minMaxLoc(netOutput.reshape(1, 1));

        return new Rect[] { new Rect(minmax.minLoc, minmax.maxLoc) };
    }

    void display(Mat frame, Rect[] faces, Scalar color)
    {

        /*
        for (int i = 0; i < faces.Length; i++)
		{
			frame.Rectangle(faces[i], color, 2);
		}*/

        Texture2D newTexture = new Texture2D(frame.width(), frame.height());
        Utils.matToTexture2D(frame, newTexture);
        GetComponent<CanvasRenderer>().SetTexture(newTexture);
    }

    private static void createDirIfNotExists(string dir)
    {
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    private static string getStorageRootDir()
    {
        return Path.Combine(Application.persistentDataPath, "screenshots");
    }

    public static string ScreenShotName(string root, int width, int height)
    {
        return string.Format("{0}/screen_{1}x{2}_{3}.png",
                             root,
                             width, height,
                             DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    /*
    // takePhoto used for shutter button onClick event
    public void takePhoto()
    {
        Texture2D screenShot = (Texture2D) newTexture;
        byte[] bytes = screenShot.EncodeToPNG();

        string storageRoot = getStorageRootDir();
        createDirIfNotExists(storageRoot);

        string filename = ScreenShotName(storageRoot, resWidth, resHeight);

        File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("SecurityAR: saved image to: {0}", filename));
    }
    */

    public void liveMode()
    {
        live = !live;
        Debug.Log("Live Mode is currently" + live);
    }


    /*
    Mat blurFace(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

       return dst.GetMat();
    }
    */
}