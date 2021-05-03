﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Tracking;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;

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

    private int rectArea(OpenCvSharp.Rect rect) => rect.Width * rect.Height;

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().SetTexture(_webCamTexture);
        
        //Use OpenCV to find face _webCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

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
        Texture2D screenShot = (Texture2D) newTexture;
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


    Mat blurFace(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

       return dst.GetMat();
    }
}