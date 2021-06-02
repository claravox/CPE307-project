using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.UnityUtils.Helper;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.DnnModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.ImgcodecsModule;
using System.IO;
using OpenCVForUnity.UtilsModule;

public abstract class BlurMethods : MonoBehaviour
{
    private static string imgPath = Application.streamingAssetsPath + "/Images";
    /// <summary>
    /// Get kernel for given width and height
    /// </summary>
    /// <param name="width">the original width of the image</param>
    /// <param name="height">the original height of the image</param>
    /// <returns>Kernel size of the gaussian blur</returns>
    private static Size KernelDimensions(int width, int height) => new Size((width / 2) | 1, (height / 2) | 1);
    
    private static Mat gaussian(Mat boundedFace)
    {
        Imgproc.GaussianBlur(boundedFace, boundedFace,
            KernelDimensions(boundedFace.width(), boundedFace.height()), 0);
        return boundedFace;
    }


    /*TODO: need to be updated with openCVforUnity*/

    private static Mat pixel(Mat boundedFace)
    {
        float pScale = 0.08f;
        Size dSize = new Size(boundedFace.cols() * pScale, boundedFace.rows() * pScale);
        Size oSize = new Size(boundedFace.cols(), boundedFace.rows());
        Mat pixelated = new Mat(dSize, CvType.CV_32SC1);
        //size down
        Imgproc.resize(boundedFace, pixelated, dSize);
        //size up
        Imgproc.resize(pixelated, boundedFace, oSize);

        return boundedFace;
    }

    private static Mat image(Mat boundedFace, string type)
    {
        Mat image = Imgcodecs.imread(imgPath + "/" + type + ".png", Imgcodecs.IMREAD_UNCHANGED);
        if (image == null)
        {
            Debug.Log("The image " + type + " is not found");
            return null;
        }

        //scale the img
        Mat scaledImage = new Mat(boundedFace.rows(), boundedFace.cols(), CvType.CV_32F);

        // resize image to match size of bounded face 
        Imgproc.resize(image, scaledImage, boundedFace.size());

        // opencv's imread reads the image into a matrix in BGR format,
        // but unity expects RGBA so we have to convert...
        Imgproc.cvtColor(scaledImage, scaledImage, Imgproc.COLOR_BGR2RGBA);
        Core.add(boundedFace, scaledImage, boundedFace);
        
        return boundedFace;
    }

    public static void blurOptionExecute(Mat frame, Rect faceLocation, CameraViewManager.blurOption BlurType)
    {

        switch (BlurType)
        {
            case (CameraViewManager.blurOption.gaussian):
                {
                    gaussian(getSubMat(frame, faceLocation));
                    break;
                }
            case (CameraViewManager.blurOption.pixel):
                {
                    pixel(getSubMat(frame, faceLocation));
                    break;
                }
            case (CameraViewManager.blurOption.flower):
                {
                    image(getSquareMat(frame, faceLocation), "flower");
                    break;
                }
            case (CameraViewManager.blurOption.mask):
                {
                    image(getSquareMat(frame, faceLocation), "mask");
                    break;
                }
            case (CameraViewManager.blurOption.face):
                {
                    image(getSquareMat(frame, faceLocation), "face");
                    break;
                }
        }
    }

    private static Mat getSubMat(Mat frame, Rect Location)
    {
        Mat subFrame = frame.submat(
        Location.y,
        Location.y + Location.height,
        Location.x,
        Location.x + Location.width);

        return subFrame;
    }

    /// <summary>
    /// This function will always return a subMat that is a square.
    /// </summary>
    /// <param name="frame"></param>
    /// <param name="Location"></param>
    /// <returns></returns>
    private static Mat getSquareMat(Mat frame, Rect Location)
    {
        //deside the side length, take the longer side
        float sideLength, deltaLength; 
        if (Location.width > Location.height)
        {
            sideLength = Location.width;
            deltaLength = sideLength - Location.height;
            Location.y -= (int)deltaLength / 2;
        }
        else
        {
            sideLength = Location.height;
            deltaLength = sideLength - Location.width;
            Location.x -= (int)deltaLength / 2;
        }

        //enlarge the square a bit. 
        Mat subFrame = frame.submat(
        Location.y,
        Location.y + (int)sideLength,
        Location.x,
        Location.x + (int)sideLength);

        return subFrame;
    }
}
