
using System.Collections.Generic;
using UnityEngine;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.ImgcodecsModule;
using OpenCVForUnity.UtilsModule;
using OpenCVForUnity.UnityUtils;

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
        Mat scaledImage = new Mat(boundedFace.height(), boundedFace.width(), CvType.CV_8UC3);

        // resize image to match size of bounded face 
        Imgproc.resize(image, scaledImage, boundedFace.size());

        // opencv's imread reads the image into a matrix in BGR format,
        // but unity expects RGBA so we have to convert...
        Imgproc.cvtColor(scaledImage, scaledImage, Imgproc.COLOR_BGR2RGBA);

        //Extract the alpha channel of the image
        List<Mat> imageChannels = new List<Mat>(4);
        Core.split(scaledImage, imageChannels);
        Mat alphaMask = imageChannels[3];

        Imgproc.cvtColor(alphaMask, alphaMask, CvType.CV_8UC1);

        Imgproc.cvtColor(alphaMask, alphaMask, Imgproc.COLOR_BGR2RGBA);

        AlphaBlend_getput(scaledImage, boundedFace, alphaMask, boundedFace);

        return boundedFace;
    }
    private static void AlphaBlend_getput(Mat fg, Mat bg, Mat alpha, Mat dst)
    {
        byte[] fg_byte = new byte[fg.total() * fg.channels()];
        fg.get(0, 0, fg_byte);
        byte[] bg_byte = new byte[bg.total() * bg.channels()];
        bg.get(0, 0, bg_byte);
        byte[] alpha_byte = new byte[alpha.total() * alpha.channels()];
        alpha.get(0, 0, alpha_byte);

        int pixel_i = 0;
        int channels = (int)bg.channels();
        int total = (int)bg.total();

        for (int i = 0; i < total*channels; i+=4)
        {
            int sum = alpha_byte[i] + alpha_byte[i + 1] + alpha_byte[i + 2];
            if (sum > 255)
                sum = 255;
            if (sum == 0)
            {
            }
            else if (sum == 255)
            {
                bg_byte[pixel_i] = fg_byte[pixel_i];
                bg_byte[pixel_i + 1] = fg_byte[pixel_i + 1];
                bg_byte[pixel_i + 2] = fg_byte[pixel_i + 2];
                bg_byte[pixel_i + 3] = fg_byte[pixel_i + 3];
            }
            else
            {
                bg_byte[pixel_i] = (byte)((fg_byte[pixel_i] * alpha_byte[i] + bg_byte[pixel_i] * (255 - alpha_byte[i])) >> 8);
                bg_byte[pixel_i + 1] = (byte)((fg_byte[pixel_i + 1] * alpha_byte[i] + bg_byte[pixel_i + 1] * (255 - alpha_byte[i])) >> 8);
                bg_byte[pixel_i + 2] = (byte)((fg_byte[pixel_i + 2] * alpha_byte[i] + bg_byte[pixel_i + 2] * (255 - alpha_byte[i])) >> 8);
                bg_byte[pixel_i + 3] = (byte)((fg_byte[pixel_i + 3] * alpha_byte[i] + bg_byte[pixel_i + 3] * (255 - alpha_byte[i])) >> 8);
            }
            pixel_i += channels;
        }

        dst.put(0, 0, bg_byte);
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

        Vector2 lowerL, upperR;
        lowerL = boundaryCheck(frame, new Vector2(Location.x, Location.y));
        upperR = boundaryCheck(frame, new Vector2(Location.x + (int)sideLength, Location.y + (int)sideLength));
        //enlarge the square a bit. 
        Mat subFrame = frame.submat((int)lowerL.y, (int)upperR.y, (int)lowerL.x, (int)upperR.x);

        return subFrame;
    }

    /// <summary>
    /// check if the vec2 point is inside the frame, if not, return a limit point within the frame
    /// </summary>
    /// <param name="frame">reference frame</param>
    /// <param name="corner"></param>
    /// <returns>return a corner vec2 point within the frame</returns>
    private static Vector2 boundaryCheck(Mat frame, Vector2 corner)
    {
        Vector2 res = corner;
        if (res.x < 0) res.x = 0;
        else if (res.x > frame.width()) res.x = frame.width();
        if (res.y < 0) res.y = 0;
        else if (res.y > frame.height()) res.y = frame.height();

        return res;
    }

}
