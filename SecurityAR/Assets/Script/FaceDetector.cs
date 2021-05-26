using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.DnnModule;
using OpenCVForUnity.ImgprocModule;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.UnityUtils.Helper;
using OpenCVForUnity.TrackingModule;


[RequireComponent(typeof(WebCamTextureToMatHelper))]
public class FaceDetector : MonoBehaviour
{
    /// <summary>
    /// Face Locations
    /// </summary>
    private Rect[] maybeFaces;
    private Rect[] boxes;

    private Net classifier = null;

    const string prototxtFileName = "deploy.prototxt.txt";
    const string caffeModelFileName = "res10_300x300_ssd_iter_140000_fp16.caffemodel";

    const float ConfidenceThreshold = 0.8f;

    List<string> outBlobTypes;

    void Start()
    {
        loadModel();
    }

    /*CORE FACE DETECTION METHODS*/
    /// <summary>
    /// Get the face locations inside the frame as a Rect Array
    /// </summary>
    /// <param name="frame">unprocessed image</param>
    /// <returns>rect array</returns>
    public Rect[] getFaceLocation(Mat frame)
    {
        maybeFaces = findNewfaces(frame);
        if (maybeFaces.Length <= 0)
        {
            Debug.Log("FaceDetector: face location list is empty");
            return null;
        }
        Array.Sort(maybeFaces, (Rect r1, Rect r2) => rectArea(r2).CompareTo(rectArea(r1)));
   
        return maybeFaces;
    }

    private Rect[] findNewfaces(Mat frame)
    {

        Mat blob;
        Size imageSize = new Size(300, 300);

       
        Mat bgrMat = new Mat(frame.rows(), frame.cols(), CvType.CV_32F);
        Imgproc.cvtColor(frame, bgrMat, Imgproc.COLOR_RGBA2BGR);
        Imgproc.resize(bgrMat, bgrMat, imageSize);
        // blob = Dnn.blobFromImage(bgrMat, 1.0, imageSize, new Scalar(104.0, 177.0, 123.0));
        blob = Dnn.blobFromImage(bgrMat, 1.0, imageSize, new Scalar(0, 0, 0), false);
        //New Mat with different Color mode

        Debug.Log($"classifier native address: {classifier.getNativeObjAddr()}");
        classifier.setInput(blob);

        List<Mat> outputs = new List<Mat>();
        classifier.forward(outputs);

        return processOutputs(outputs, frame);
    }

    private Rect[] processOutputs(List<Mat> outputs, Mat frame)
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

    private void loadModel()
    {
        string caffePath = getStreamingAssetsFilePath(caffeModelFileName);
        string protoTxtPath = getStreamingAssetsFilePath(prototxtFileName);

        Debug.Log($"Caffe path: {caffePath}; protoTxtPath: {protoTxtPath}");

        Debug.Log($"caffe path exists? {File.Exists(caffePath)}");

        classifier = Dnn.readNetFromCaffe(protoTxtPath,
            caffePath);

        Debug.Log($"classifier == null: {classifier == null}");

        //outBlobTypes = getOutputsTypes(classifier);
        //Debug.Log($"out blob type: {outBlobTypes[0]}");
    }

    private string getStreamingAssetsFilePath(string fileName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        if (onAndroid)
        {
            path = createStaticAndroidFile(path,
                fileName);
        }

        return path;
    }


    //HELPER FUNCTION
    /// <summary>
    /// Get area of a given rectangle
    /// </summary>
    /// <param name="rect"></param>
    /// <returns>return area in int of the rectangle</returns>
    private int rectArea(Rect rect) => rect.width * rect.height;


    /*PLATFORM CHECK*/
    bool onAndroid { get { return Application.platform == RuntimePlatform.Android; } }
    bool onIOS { get { return Application.platform == RuntimePlatform.IPhonePlayer; } }
    bool onMobile { get { return onAndroid || onIOS; } }

    private string checkDeviceType()
    {
        string m_DeviceType = null;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            m_DeviceType = "Desktop";
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_DeviceType = "Handheld";
        }
        return m_DeviceType;
    }

    /*ANDROID SPECIFIC*/
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

            //var text = task.webRequest.downloadHandler.text;
            var data = task.webRequest.downloadHandler.data;
            string targetPath = Path.Combine(Application.persistentDataPath, newName);
            
            File.WriteAllBytes(targetPath, data);
            
            return targetPath;
        }
    }


}