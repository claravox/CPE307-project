using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    
    OpenCvSharp.Rect MyFace;

    // Start is called before the first frame update
    void Start()
    {  
        WebCamDevice[] devices = WebCamTexture.devices;

        _webCamTexture = new WebCamTexture(devices[0].name, 1920, 1080, 60);
        _webCamTexture.Play();
        cascade = new CascadeClassifier(Application.dataPath + @"/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
    }

    private Size kernelDimensions(int width, int height) => new Size( (width / 7) | 1, (height / 7) | 1);

    const int FrameResetThreshold = 120;
    bool trackingFace;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = _webCamTexture;
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

        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }


    Mat blurFace(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

       return dst.GetMat();
    }
}