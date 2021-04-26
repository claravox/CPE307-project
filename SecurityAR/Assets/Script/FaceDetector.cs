using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    Texture newTexture;
    public int resWidth = 2550;
    public int resHeight = 3300;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        float width = GetComponentInParent<RectTransform>().rect.width;
        float height = GetComponentInParent<RectTransform>().rect.height;
        Debug.Log("width = " + width);
        Debug.Log("height = " + height);

        _webCamTexture = new WebCamTexture(devices[0].name, (int)width, (int)height, 60);
        //_webCamTexture = new WebCamTexture(devices[0].name);

        _webCamTexture.Play();
        Debug.Log("webcam width = " + _webCamTexture.width);
        Debug.Log("webcam height = " + _webCamTexture.height);
        cascade = new CascadeClassifier(Application.dataPath + @"/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);
        //GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        findNewface(frame);
        display(frame);
    }

    void findNewface(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        if (faces.Length >= 1)
        {
            //Debug.Log(faces[0].Location);
            MyFace = faces[0];
        }
    }

    void display(Mat frame)
    {
        if(MyFace != null)
        {
            frame.Rectangle(MyFace, new Scalar(250, 0, 0), 2);
        }
        newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        
        //GetComponent<Renderer>().material.mainTexture = newTexture;
        GetComponent<CanvasRenderer>().SetTexture(newTexture);
    }

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void takePhoto()
    {
        Texture2D screenShot = (Texture2D)newTexture;
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }

}
