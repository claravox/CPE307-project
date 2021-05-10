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
    public WebCamTexture _defaultCamTexture;
    private WebCamTexture _frontCamTexture;
    private WebCamTexture _backCamTexture;
    String frontCamName, backCamName;
    CascadeClassifier cascade;

    Texture newTexture;

    public OpenCvSharp.Rect[] Face;

    public Sprite[] imagePrefabs;
    public enum blurOption { gaussian, pixel, face, flower, mask };
    public blurOption BlurType;

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
    ImageFollowFace imageOverlay;
    void Start()
    {
        imageOverlay = GameObject.Find("ImageFaceOverlay").GetComponent<ImageFollowFace>();
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamDevice camera;

        //No device is availble
        if (devices.Length == 0)
        {
            Debug.Log("There is no camera device availble");
            this.enabled = false;
            return;
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
                    _frontCamTexture = new WebCamTexture(frontCamName, resWidth, resHeight, 60);
                }
                else
                {
                    backCamName = devices[i].name;
                    _backCamTexture = new WebCamTexture(backCamName, resWidth, resHeight, 60);
                }
            }

            //set default to front if there is front
            if (_frontCamTexture != null)
                _defaultCamTexture = _frontCamTexture;
            else
                _defaultCamTexture = _backCamTexture;

            //_defaultCamTexture = new WebCamTexture(devices[0].name, (int)width, (int)height, 60);
            _defaultCamTexture.Play();
            float newXScale = _defaultCamTexture.width / width;
            float newYScale = _defaultCamTexture.height / height;
            Vector3 newScale = new Vector3(newXScale, newYScale, 1.0f);
            GetComponentInParent<RectTransform>().transform.localScale = newScale;
            cascade = new CascadeClassifier(getClassifierDataPath());
        }
    }

    // Update is called once per frame
    void Update()
    {
        float width = GetComponentInParent<RectTransform>().rect.width;
        float height = GetComponentInParent<RectTransform>().rect.height;
        float newXScale = _defaultCamTexture.width / width;
        float newYScale = _defaultCamTexture.height / height;
        Vector3 newScale = new Vector3(newXScale, newYScale, 1.0f);
        GetComponentInParent<RectTransform>().transform.localScale = newScale;

        GetComponent<CanvasRenderer>().SetTexture(_defaultCamTexture);

        //Use OpenCV to find face _defaultCamTexture
        Mat frame = OpenCvSharp.Unity.TextureToMat(_defaultCamTexture);

        /*
        if (onMobile)
        {
            frame.Rotate(RotateFlags.Rotate90Clockwise);
        }*/

        OpenCvSharp.Rect[] maybeFaces = findNewfaces(frame);
        Face = maybeFaces;
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
        //Debug.Log(string.Format("{0}", string.Join(",", areas)));

        for (int i = 1; i < maybeFaces.Length; i++)
        {
            OpenCvSharp.Rect face = maybeFaces[i];
            Mat subFrame = frame
                .ColRange(face.Location.X, face.Location.X + face.Width)
                .RowRange(face.Location.Y, face.Location.Y + face.Height);
                blurOptionExecute(subFrame);
        }


        if (live)
            display(frame, maybeFaces, new Scalar(250, 0, 0));
        else
            imageOverlay.disableImageOverlay();
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
    private Size kernelDimensions(int width, int height) => new Size((width / 7) | 1, (height / 7) | 1);

    private int rectArea(OpenCvSharp.Rect rect) => rect.Width * rect.Height;


    public void setMode(int modeIndex)
    {
        switch (modeIndex)
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
        return cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage, new Size(100, 100));
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