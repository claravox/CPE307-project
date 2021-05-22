using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rect = OpenCVForUnity.CoreModule.Rect;


public class ImageOverlayManager : MonoBehaviour
{
    public GameObject ImagePrefab;
 
    Rect[] faces;
    List<GameObject> images = new List<GameObject>();

    List<GameObject> prevImages = new List<GameObject>();
    List<GameObject> prevPrevImages = new List<GameObject>();
    string Imagetype;


    void Start()
    {
        Imagetype = "flower";
        this.enabled = false;
    }

    void Update()
    {
        // TODO could this go in start?
        GameObject cameraView = GameObject.Find("Canvas");

        //get face count
        faces = GameObject.Find("Quad").GetComponent<FaceDetector>().resultObjects.ToArray();

        // Move our lists along

       foreach(GameObject img in prevPrevImages) {
           GameObject.Destroy(img);
       }
       prevPrevImages.Clear();

       prevPrevImages = prevImages;
       prevImages = images;
       images = new List<GameObject>();

       for (int i = 1; i < faces.Length && i < 10; i++) {
            Rect faceLocation = faces[i];
            float x = cameraView.transform.position.x - cameraView.GetComponent<RectTransform>().rect.width * cameraView.GetComponent<RectTransform>().localScale.x / 2 + faceLocation.x + faceLocation.width / 2;
            float y = cameraView.transform.position.y + cameraView.GetComponent<RectTransform>().rect.height * cameraView.GetComponent<RectTransform>().localScale.y / 2 - faceLocation.y - faceLocation.height/2;
            float x_scale = faceLocation.width / 100.0f;
            float y_scale = faceLocation.height / 100.0f; 
            float resScale = 1.0f;
            if (faceLocation.width >= faceLocation.height)
                resScale = x_scale * 1.3f;
            else
                resScale = y_scale * 1.3f;


            Vector3 facePos = new Vector3(x, y, cameraView.transform.position.z);
            GameObject aImage = GameObject.Instantiate(ImagePrefab, this.gameObject.transform);
            aImage.GetComponent<RectTransform>().localScale = new Vector3(resScale, resScale, 1);
            aImage.transform.position = facePos;
            aImage.SetActive(true);
            images.Add(aImage);

       }
    }

    // void instantiateImage()
    // {
    //     Transform Spawn = this.gameObject.transform;
    //     if(LastRemovedImgTransform != null)
    //     {
    //         Spawn = LastRemovedImgTransform;
    //     }
    //     GameObject aImage = GameObject.Instantiate(ImagePrefab, Spawn);
    //     images.Add(aImage);
    // }

    public void changeImageType(string name)
    {
        Imagetype = name;
        if (images.Count == 0)
            return;
        foreach(GameObject img in images)
        {
            img.GetComponent<ImageFollowFace>().changeImage(name);
        }
    }

    public void enableImage()
    {
        this.enabled = true;
    }

    public void disableImage()
    {
        foreach(GameObject img in images)
        {
            GameObject.Destroy(img);
        }
        images.Clear();
        this.enabled = false;
    }
}
