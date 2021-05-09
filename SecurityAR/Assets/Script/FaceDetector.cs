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

    private Size kernelDimensions(int width, int height) => new Size( (width / 7) | 1, (height / 7) | 1);

    const int FrameResetThreshold = 120;
    bool trackingFace;

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);
        
        //Use OpenCV to find face _webCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        int width = frame.Width;
        int height = frame.Height;

        //for loop this bad boy
        OpenCvSharp.Rect[] maybeFaceLoc = findNewfaces(frame);
        if (maybeFaceLoc.Length <= 0)
        {
            return;
        }

        //OpenCvSharp.Rect faceLoc = maybeFaceLoc.Value;

        for (int i = 0; i < maybeFaceLoc.Length; i++)
		  {
			    Mat subFrame = frame
            .ColRange(maybeFaceLoc[i].Location.X, maybeFaceLoc[i].Location.X + maybeFaceLoc[i].Width)
            .RowRange(maybeFaceLoc[i].Location.Y, maybeFaceLoc[i].Location.Y + maybeFaceLoc[i].Height);

        		blurFace(subFrame);
		   }
        
        if(live)
        display(frame, maybeFaceLoc);
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
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        /*if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            return faces[0];
        }*/

        return faces;
    }

    void display(Mat frame, OpenCvSharp.Rect[] face)
    {
       if(face.Length > 0)
        {
        		for (int i = 0; i < face.Length; i++)
		   {
			    frame.Rectangle(face[i], new Scalar(250, 0, 0), 2);
		   }
            
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
        Texture2D screenShot = (Texture2D)newTexture;
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