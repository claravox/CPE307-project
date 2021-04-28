using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    Texture newTexture;

    public bool live = true;

    public int resWidth = 2550;
    public int resHeight = 3300;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        
        //No device is availble
        if(devices.Length == 0)
        {
            Debug.Log("There is no camera device availble");
            this.enabled = false;
        }
        else
        {
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
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);
        
        //Use OpenCV to find face _webCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        findNewface(frame);

        if(live)
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
        GetComponent<CanvasRenderer>().SetTexture(newTexture);
    }

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    
    // takePhoto used for shutter button onClick event
    public void takePhoto()
    {
        Texture2D screenShot = (Texture2D)newTexture;
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);

        try
        {
            using (FileStream fs = File.Create(filename))
            {
                fs.Write(bytes, 0, bytes.Length);
                Debug.Log(string.Format("Took screenshot to: {0}", filename));
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Photo Not Saved: Path Invalid");
            Debug.Log(ex.ToString());
        }

    }

    public void liveMode()
    {
        live = !live;
        Debug.Log("Live Mode is currently" + live);
    }
}
