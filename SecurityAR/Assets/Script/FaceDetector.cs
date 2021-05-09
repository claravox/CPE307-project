using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using OpenCvSharp;
using UnityEngine.Networking;
using OpenCvSharp.Tracking;

public class FaceDetector : MonoBehaviour
{


    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;

    Texture newTexture;
    
    public bool live = true;
    public int resWidth = 2550;
    public int resHeight = 3300;

    bool onMobile { get { return Application.platform == RuntimePlatform.Android; } }

    const string HaarClassifierDataPathPC = @"/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml";

    string getClassifierDataPath()
    {
        if (!onMobile)
        {
            return Application.dataPath + HaarClassifierDataPathPC;
        }

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

        cascade = new CascadeClassifier(getClassifierDataPath());
    }
    

    private Size kernelDimensions(int width, int height) => new Size( (width / 7) | 1, (height / 7) | 1);

    private int rectArea(OpenCvSharp.Rect rect) => rect.Width * rect.Height;

    // Update is called once per frame
    void Update()
    {




        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);
       
        //Use OpenCV to find face _webCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        /*
        if (onMobile)
        {
            frame.Rotate(RotateFlags.Rotate90Clockwise);
        }*/

        int width = frame.Width;
        int height = frame.Height;

        OpenCvSharp.Rect[] maybeFaces = findNewfaces(frame);
        if (maybeFaces.Length <= 0)
        {
            return;
        }

        Array.Sort(maybeFaces, (OpenCvSharp.Rect r1, OpenCvSharp.Rect r2) =>
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
		}

        if (live)
        {
             display(frame, maybeFaces, new Scalar(250, 0, 0));
        }
    }

    Mat spliceImage(Mat fullFrame, OpenCvSharp.Rect portion, Mat filler)
    {
        Mat target = fullFrame
            .ColRange(portion.Location.X, portion.Location.X + portion.Width)
            .RowRange(portion.Location.Y, portion.Location.Y + portion.Height);

        filler.CopyTo(target);

        return fullFrame;
    }

    OpenCvSharp.Rect[] findNewfaces(Mat frame)
    {
    	  //Use this to do multi-face tracking
        return cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
    }

    void display(Mat frame, OpenCvSharp.Rect[] faces, Scalar color)
    {
        for (int i = 0; i < faces.Length; i++)
		{
			frame.Rectangle(faces[i], color, 2);
		}

        newTexture = OpenCvSharp.Unity.MatToTexture(frame);
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

    public void liveMode()
    {
        live = !live;
        Debug.Log("Live Mode is currently" + live);
    }


    Mat blurFace(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

       return dst.GetMat();
    }
}