﻿#if !(PLATFORM_LUMIN && !UNITY_EDITOR)


using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.UnityUtils.Helper;
using OpenCVForUnity.TrackingModule;
using System;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Rect = OpenCVForUnity.CoreModule.Rect;

[RequireComponent(typeof(WebCamTextureToMatHelper))]

public class CameraViewManager : MonoBehaviour
{
    /// <summary>
    /// Live mode bool
    /// </summary>
    public bool live = true;

    /// <summary>
    /// The texture.
    /// </summary>
    Texture2D texture;

    /// <summary>
    /// The locations of the faces in the frame
    /// </summary>
    Rect[] faceLocations;

    int faceCount;
    /// <summary>
    /// The webcam texture to mat helper.
    /// </summary>
    WebCamTextureToMatHelper webCamTextureToMatHelper;

    FaceDetector faceDetector;     

    //UI
    public enum blurOption { gaussian, pixel, face, flower, mask };
    public blurOption BlurType;

    private void OnLowMemory()
    {
        Resources.UnloadUnusedAssets();
    }

    void Start()
    {
        //start the web Cam Texture
        webCamTextureToMatHelper = gameObject.GetComponent<WebCamTextureToMatHelper>();

        webCamTextureToMatHelper.requestedHeight = Screen.currentResolution.height;
        webCamTextureToMatHelper.requestedWidth = Screen.currentResolution.width;

        GameObject rearFrontButton = GameObject.Find("RearFrnt");
        if (SystemInfo.deviceType != DeviceType.Handheld)
            rearFrontButton.SetActive(false);

        webCamTextureToMatHelper.Initialize();

        faceDetector = gameObject.GetComponent<FaceDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (webCamTextureToMatHelper.IsPlaying() && webCamTextureToMatHelper.DidUpdateThisFrame())
        {
            Mat rgbaMat = webCamTextureToMatHelper.GetMat();

            //Imgproc.putText (rgbaMat, "W:" + rgbaMat.width () + " H:" + rgbaMat.height () + " SO:" + Screen.orientation, new Point (5, rgbaMat.rows () - 10), Imgproc.FONT_HERSHEY_SIMPLEX, 1.0, new Scalar (255, 255, 255, 255), 2, Imgproc.LINE_AA, false);


            //update the canvas renderer texture;
            if (live)
            {
                
                faceLocations = faceDetector.getFaceLocation(rgbaMat);
                
                if(faceLocations != null)
                {
                    faceCount = faceLocations.Length;
                    //drawRectOverFaces(rgbaMat, faceLocations, new Scalar(0, 0, 255));
                    for (int i = 1; i < faceLocations.Length; i++)
                    {
                        //Debug.Log("BLURRING FACE");
                        Rect curFace = faceLocations[i];
                        BlurMethods.blurOptionExecute(rgbaMat, curFace, BlurType);
                    }
                }
            }

            Utils.fastMatToTexture2D(rgbaMat, texture);

        }
    }

    private void drawRectOverFaces(Mat frame, Rect[] faces, Scalar color)
    {
        Debug.Log($"faces.Length!!: {faces.Length}");
        foreach (var face in faces)
        {
            Imgproc.rectangle(frame, face, color, 5);
        }
    }

    /// <summary>
    /// Raises the webcam texture to mat helper initialized event.
    /// </summary>
    public void OnWebCamTextureToMatHelperInitialized()
    {
        Debug.Log("OnWebCamTextureToMatHelperInitialized");

        Mat webCamTextureMat = webCamTextureToMatHelper.GetMat();

        texture = new Texture2D(webCamTextureMat.cols(), webCamTextureMat.rows(), TextureFormat.RGBA32, false);
        Utils.fastMatToTexture2D(webCamTextureMat, texture);

        gameObject.GetComponent<Renderer>().material.mainTexture = texture;

        gameObject.transform.localScale = new Vector3(webCamTextureMat.cols(), webCamTextureMat.rows(), 1);

        float width = webCamTextureMat.width();
        float height = webCamTextureMat.height();

        float widthScale = (float)Screen.width / width;
        float heightScale = (float)Screen.height / height;
        if (widthScale < heightScale)
        {
            Camera.main.orthographicSize = (width * (float)Screen.height / (float)Screen.width) / 2;
        }
        else
        {
            Camera.main.orthographicSize = height / 2;
        }
    }



    /// <summary>
    /// Raises the webcam texture to mat helper disposed event.
    /// </summary>
    public void OnWebCamTextureToMatHelperDisposed()
    {
        Debug.Log("OnWebCamTextureToMatHelperDisposed");

        if (texture != null)
        {
            Texture2D.Destroy(texture);
            texture = null;
        }
    }

    /// <summary>
    /// Raises the webcam texture to mat helper error occurred event.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    public void OnWebCamTextureToMatHelperErrorOccurred(WebCamTextureToMatHelper.ErrorCode errorCode)
    {
        Debug.Log("OnWebCamTextureToMatHelperErrorOccurred " + errorCode);

        //if (fpsMonitor != null)
        //{
        //    fpsMonitor.consoleText = "ErrorCode: " + errorCode;
        //}
    }

    /*UI CONTROL METHODS*/

    /// <summary>
    /// Turn the live rendering on or off
    /// </summary>
    public void LiveMode()
    {
        live = !live;
        Debug.Log("Live Mode is currently" + live);
    }

    /// <summary>
    /// Set the mode of blurring
    /// </summary>
    /// <param name="modeIndex"></param>
    public void SetMode(int modeIndex)
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
    
    /// <summary>
    /// Save the texture2D to the default data path
    /// </summary>
    public void takePhoto()
    {
        string filename = null;
        switch (SystemInfo.deviceType)
        {
            case DeviceType.Desktop:
                {
                    filename = ScreenShotNameWithPath(texture.width, texture.height);
                    byte[] bytes;
                    bytes = texture.EncodeToPNG();
                    File.WriteAllBytes(filename, bytes);
                    break;
                }
            case DeviceType.Handheld:
                {
                    /*ANDRIOD NOTE*/
                    //Android - you must set Write Access to External (SDCard) in Player Setting
                    filename = ScreenShotName(texture.width, texture.height);
                    NativeToolkit.SaveImage(texture, filename, "png");
                    break;
                }
        }
        
        Debug.Log(string.Format("SecurityAR: saved image : {0}", filename));
    }

    /// <summary>
    /// Helper function for getting  the screen shot name
    /// </summary>
    /// <param name="width">width of the texture</param>
    /// <param name="height">height of the texture</param>
    /// <returns>screen shot name</returns>
    public static string ScreenShotName(int width, int height)
    {
        return string.Format("screen_{0}x{1}_{2}",
                             width, height,
                             DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    /// <summary>
    /// Helper function for getting  the screen shot name with the data path
    /// </summary>
    /// <param name="width">width of the texture</param>
    /// <param name="height">height of the texture</param>
    /// <returns>screen shot name with data path</returns>
    public static string ScreenShotNameWithPath(int width, int height)
    {
        string storageRoot = getStorageRootDir();
        createDirIfNotExists(storageRoot);
        string fileName = ScreenShotName(width, height);
        return string.Format("{0}/{1}.png",
                             storageRoot,
                             fileName);
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

    public void changeCamFrontFacing()
    {
        webCamTextureToMatHelper.requestedIsFrontFacing = !webCamTextureToMatHelper.requestedIsFrontFacing;
    }


}
#endif