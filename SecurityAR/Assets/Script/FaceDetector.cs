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

    private Size kernelDimensions(int width) => new Size( (width / 7) | 1, (width / 7) | 1);
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        OpenCvSharp.Rect? maybeFaceLoc = findNewface(frame);
        if (!maybeFaceLoc.HasValue)
        {
            return;
        }

        OpenCvSharp.Rect faceLoc = maybeFaceLoc.Value;

        Mat subFrame = frame
            .ColRange(faceLoc.Location.X, faceLoc.Location.X + faceLoc.Width)
            .RowRange(faceLoc.Location.Y, faceLoc.Location.Y + faceLoc.Height);
        blurFace(subFrame);

        display(frame, faceLoc);
    }

    Mat spliceImage(Mat fullFrame, OpenCvSharp.Rect portion, Mat filler)
    {
        Mat target = fullFrame
            .ColRange(portion.Location.X, portion.Location.X + portion.Width)
            .RowRange(portion.Location.Y, portion.Location.Y + portion.Height);

        filler.CopyTo(target);

        return fullFrame;
    }

    OpenCvSharp.Rect? findNewface(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            return faces[0];
        }

        return null;

    }

    void display(Mat frame, OpenCvSharp.Rect face)
    {
       if(face != null)
        {
            frame.Rectangle(face, new Scalar(250, 0, 0), 2);
        }

        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }


    Mat blurFace(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width), 0);

       return dst.GetMat();
    }
}