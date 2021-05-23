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
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UtilsModule;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.UnityUtils.Helper;


[RequireComponent(typeof(WebCamTextureToMatHelper))]
public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    //CascadeClassifier cascade;

    Net classifier = null;

    public bool live = true;
    public int resWidth = 2550;
    public int resHeight = 3300;

    bool onAndroid { get { return Application.platform == RuntimePlatform.Android; } }
    bool onIOS { get { return Application.platform == RuntimePlatform.IPhonePlayer; } }
    bool onMobile { get { return onAndroid || onIOS; } }

    const string prototxtFileName = "deploy.prototxt.txt";
    const string caffeModelFileName = "res10_300x300_ssd_iter_140000_fp16.caffemodel";

    const float ConfidenceThreshold = 0.8f;

    Mat bgaMat;

    List<string> outBlobTypes;

    string createStaticAndroidFile(string assetUrl, string newName)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(assetUrl))
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

            string targetPath = Path.Combine(Application.persistentDataPath, newName);
            if (!File.Exists(targetPath))
            {
                File.WriteAllText(targetPath, text);
            }

            return targetPath;
        }
    }

    string getStreamingAssetsFilePath(string fileName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        if (onAndroid)
        {
            path = createStaticAndroidFile(path,
                fileName);
        }

        return path;
    }

    void loadModel()
    {

        string caffePath = getStreamingAssetsFilePath(caffeModelFileName);
        string protoTxtPath = getStreamingAssetsFilePath(prototxtFileName);

        Debug.Log($"Caffe path: {caffePath}; protoTxtPath: {protoTxtPath}");

        
        classifier = Dnn.readNetFromCaffe(protoTxtPath,
            caffePath);

        Debug.Log($"classifier == null: {classifier == null}");
        
        //outBlobTypes = getOutputsTypes(classifier);

        //Debug.Log($"out blob type: {outBlobTypes[0]}");
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

        loadModel();
    }
    

    private Size kernelDimensions(int width, int height) => new Size((width / 2) | 1, (height / 2) | 1);

    private int rectArea(Rect rect) => rect.width * rect.height;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(string.Format("classifier: {0}", classifier));
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);

        Mat frame = new Mat(_webCamTexture.height, _webCamTexture.width, CvType.CV_8UC4, new Scalar(0, 0, 0, 255));
   
        //Use OpenCV to find face _webCamTexture
        Utils.webCamTextureToMat(_webCamTexture, frame);

        int width = frame.width();
        int height = frame.height();
        
        Rect[] maybeFaces = findNewfaces(frame);
        if (maybeFaces.Length <= 0)
        {
            Debug.Log("No faces detected");
            return;
        }

        Rect face = maybeFaces[0];

        Debug.Log(string.Format("Detected Face At: ({0}, {1}) width={2} height={3}",
            face.x, face.y, face.width, face.height));
        
        Array.Sort(maybeFaces, (Rect r1, Rect r2) =>
            rectArea(r2).CompareTo(rectArea(r1)));
        
        for (int i = 1; i < maybeFaces.Length; i++)
        {
            Debug.Log("BLURRING FACE");
              Rect curFace = maybeFaces[i];
              Mat subFrame = frame.submat(
                  curFace.y,
                  curFace.y + curFace.height,
                  curFace.x,
                  curFace.x + curFace.width);

              blurFace(subFrame);
        }

        if (live)
        {
            display(frame, maybeFaces, new Scalar(0, 0, 250));
        }
    }

    Rect[] findNewfaces(Mat frame)
    {
        bgaMat = new Mat(frame.rows(), frame.cols(), CvType.CV_8UC3);

        Imgproc.cvtColor(frame, bgaMat, Imgproc.COLOR_RGBA2BGR);
        Size imageSize = new Size(300, 300);

        Mat blob = Dnn.blobFromImage(bgaMat, 1.0, imageSize, new Scalar(104.0, 177.0, 123.0));

        classifier.setInput(blob);
        
        List<Mat> outputs = new List<Mat>();
        classifier.forward(outputs);

        return processOutputs(outputs, frame);
    }

    Rect[] processOutputs(List<Mat> outputs, Mat frame)
    {
        Debug.Log($"Outputs: {outputs}");
        if (outputs.Count != 1)
        {
            throw new Exception("Unexpected output blob length");
        }

        List<Rect> boundingBoxes = new List<Rect>();

        Mat output = outputs[0];
        output = output.reshape(1, ((int)output.total()) / 7);
   

        float[] row = new float[7];
        for (int j = 0; j < output.rows(); j++)
        {
            output.get(j, 0, row);
            float conf = row[2];

            if (conf > ConfidenceThreshold)
            {
                //float id = row[1];
                float left = row[3] * frame.cols();
                float top = row[4] * frame.rows();
                float right = row[5] * frame.cols();
                float bottom = row[6] * frame.rows();
                float width = right - left + 1;
                float height = bottom - top + 1;

                boundingBoxes.Add(new Rect((int)left, (int)top, (int)width, (int)height));
                //Debug.Log($"id: {id}; conf: {conf}; left:{left};top:{top};width:{width};height:{height}");
            }
        }

        return boundingBoxes.ToArray();
    }

    protected virtual List<string> getOutputsTypes(Net net)
    {
        List<string> types = new List<string>();

        MatOfInt outLayers = net.getUnconnectedOutLayers();
        for (int i = 0; i < outLayers.total(); ++i)
        {
            types.Add(net.getLayer(new DictValue((int)outLayers.get(i, 0)[0])).get_type());
        }
        outLayers.Dispose();

        return types;
    }

    void display(Mat frame, Rect[] faces, Scalar color)
    {
        Debug.Log($"faces.Length!!: {faces.Length}");

        foreach (var face in faces)
        {
            Imgproc.rectangle(frame, face, color, 5);
        }

        Texture2D newTexture = new Texture2D(frame.cols(), frame.rows());
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
    
    Mat blurFace(Mat boundedFace)
    {
        Imgproc.GaussianBlur(boundedFace, boundedFace,
            kernelDimensions(boundedFace.width(), boundedFace.height()), 0);
        //InputArray src = new InputArray(boundedFace);
        // OutputArray dst = new OutputArray(boundedFace);
        // Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

        return boundedFace;
    }
}