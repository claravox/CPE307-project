using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    public WebCamTexture _defaultCamTexture;
    private WebCamTexture _frontCamTexture;
    private WebCamTexture _backCamTexture;
    String frontCamName, backCamName;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    Texture newTexture;

    public OpenCvSharp.Rect[] Face;

    public Sprite[] imagePrefabs;
    public enum blurOption {gaussian, pixel, face, flower, mask};
    public blurOption BlurType;

    public bool live = true;
    public int resWidth = 2550;
    public int resHeight = 3300;

    ImageFollowFace imageOverlay;
    // Start is called before the first frame update
    void Start()
    {
        imageOverlay = GameObject.Find("ImageFaceOverlay").GetComponent<ImageFollowFace>();

        WebCamDevice[] devices = WebCamTexture.devices;

        //No device is availble
        if (devices.Length == 0)
        {
            Debug.Log("There is no camera device availble");
            this.enabled = false;
        }
        else
        {

            float width = GetComponentInParent<RectTransform>().rect.width;
            float height = GetComponentInParent<RectTransform>().rect.height;

            for (var i = 0; i < devices.Length; i++)
            {
                if (devices[i].isFrontFacing)
                {
                    frontCamName = devices[i].name;
                    _frontCamTexture = new WebCamTexture(frontCamName);
                }
                else
                {
                    backCamName = devices[i].name;
                    _backCamTexture = new WebCamTexture(backCamName);
                }
            }

            //set default to front if there is front
            if (_frontCamTexture != null)
                _defaultCamTexture = _frontCamTexture;
            else
                _defaultCamTexture = _backCamTexture;


            //_defaultCamTexture = new WebCamTexture(devices[0].name, (int)width, (int)height, 60);
            _defaultCamTexture = new WebCamTexture(devices[0].name);

            _defaultCamTexture.Play();
            float newXScale = _defaultCamTexture.width / width;
            float newYScale = _defaultCamTexture.height / height;
            Vector3 newScale = new Vector3(newXScale, newYScale, 1.0f); 
            GetComponentInParent<RectTransform>().transform.localScale = newScale;

            Debug.Log("webcam width = " + _defaultCamTexture.width);
            Debug.Log("webcam height = " + _defaultCamTexture.height);
            cascade = new CascadeClassifier(Application.dataPath + @"/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
        }
    }

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
    private Size kernelDimensions(int width, int height) => new Size( (width / 7) | 1, (height / 7) | 1);

    const int FrameResetThreshold = 120;
    bool trackingFace;

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().SetTexture(_defaultCamTexture);
        
        //Use OpenCV to find face _defaultCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_defaultCamTexture);

        //for loop this bad boy
        OpenCvSharp.Rect[] maybeFaceLoc = findNewfaces(frame);
        if (maybeFaceLoc.Length <= 0)
        {
            return;
        }

        // Temporary, eventually want this to applied to all faces in for loop like below
        Face = maybeFaceLoc;
        //OpenCvSharp.Rect faceLoc = maybeFaceLoc.Value;

        for (int i = 0; i < maybeFaceLoc.Length; i++)
		  {
			Mat subFrame = frame
                .ColRange(maybeFaceLoc[i].Location.X, maybeFaceLoc[i].Location.X + maybeFaceLoc[i].Width)
                .RowRange(maybeFaceLoc[i].Location.Y, maybeFaceLoc[i].Location.Y + maybeFaceLoc[i].Height);
            blurOptionExecute(subFrame);
		   }

        if (live)
            display(frame, maybeFaceLoc);
        else
            imageOverlay.disableImageOverlay();
    }

    public void setMode(int modeIndex)
    {
        switch(modeIndex)
        {
            case 0:
                {
                    BlurType = blurOption.gaussian;
                    break;
                }
            case 1:
                {
                    BlurType = blurOption.pixel;
                    break;
                }
            case 2:
                {
                    BlurType = blurOption.flower;
                    break;
                }
            case 3:
                {
                    BlurType = blurOption.face;
                    break;
                }
            case 4:
                {
                    BlurType = blurOption.mask;
                    break;
                }
        }
    }

    void blurOptionExecute(Mat frame)
    {
        switch (BlurType)
        {
            case (blurOption.gaussian):
                {
                    imageOverlay.disableImageOverlay();
                    gaussian(frame);
                    break;
                }
            case (blurOption.pixel):
                {
                    imageOverlay.disableImageOverlay();
                    pixel(frame);
                    break;
                }
            case (blurOption.flower):
                {
                    image("flower");
                    break;
                }
            case (blurOption.mask):
                {
                    image("mask");
                    break;
                }
            case (blurOption.face):
                {
                    image("face");
                    break;
                }
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
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage, new Size(100,100));
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


    Mat gaussian(Mat boundedFace)
    {
        InputArray src = new InputArray(boundedFace);
        OutputArray dst = new OutputArray(boundedFace);
        Cv2.GaussianBlur(src, dst, kernelDimensions(boundedFace.Width, boundedFace.Height), 0);

       return dst.GetMat();
    }

    Mat pixel(Mat boundedFace)
    {
        float pScale = 0.08f;
        Size dSize = new Size(boundedFace.Cols * pScale, boundedFace.Rows * pScale);
        Size oSize = new Size(boundedFace.Cols, boundedFace.Rows);
        Mat pixelated = new Mat(dSize, MatType.CV_32S);
        Cv2.Resize(boundedFace, pixelated, dSize);
        Cv2.Resize(pixelated, boundedFace, oSize);
        return boundedFace;
    }

    void image(string type)
    {
        imageOverlay.changeImage(type);
        imageOverlay.enableImageOverlay();
    }

}