using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.CoreModule;

public class ImageOverlayManager : MonoBehaviour
{
    public GameObject ImagePrefab;
 
    Rect[] faces;
    static int lastFaceCount = 0;
    List<GameObject> images = new List<GameObject>();
    Transform LastRemovedImgTransform;
    string Imagetype;
    void Start()
    {
        Imagetype = "flower";
        this.enabled = false;
    }

    void FixedUpdate()
    {
        //get face count
        faces = GameObject.Find("CameraView").GetComponent<FaceDetector>().face;
        //if face count changed, change the amount of images as well
        //there is always 1 image less the faces
        if (lastFaceCount != faces.Length)
        {
            
            int change = lastFaceCount - faces.Length;
            //less face, destroy image that's newly added
            if (change > 0)
            {
                for (int i = 0; i < change; i++)
                {
                    
                    LastRemovedImgTransform = images[images.Count - 1].transform;
                    GameObject.Destroy(images[images.Count - 1]);
                    images.RemoveAt(images.Count-1);
                }
            }
            //more face, add image
            else if (change < 0)
            {
                change = -change;
                for (int i = 0; i < change; i++)
                {
                    instantiateImage();
                }
            }
            lastFaceCount = faces.Length;
        }

        // each image follows a face in the array except the first face
        for (int i = 0; i < lastFaceCount; i++)
        {
            Rect face = faces[i];
            images[i].GetComponent<ImageFollowFace>().faceLocation = face;

            if (i == 0)
            {
                images[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    void instantiateImage()
    {
        Transform Spawn = this.gameObject.transform;
        if(LastRemovedImgTransform != null)
        {
            Spawn = LastRemovedImgTransform;
        }
        GameObject aImage = GameObject.Instantiate(ImagePrefab, Spawn);
        images.Add(aImage);
    }

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
        lastFaceCount = 0;
        this.enabled = false;
    }
}
