using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rect = OpenCVForUnity.CoreModule.Rect;


public class ImageFollowFace : MonoBehaviour
{

    GameObject cameraView;
    Image imageRender;
    
    public Rect faceLocation;
    public Vector3 facePos, newScale;
    public List<Sprite> images;

    // Start is called before the first frame update
    public void Start()
    {
        imageRender = this.GetComponent<Image>();
        imageRender.enabled = true;
        cameraView = GameObject.Find("CameraView");
        this.enabled = true;
    }

    public void changeImage(string name)
    {
        if (name == null)
            return;
        switch (name)
        {
            case "flower":
                {
                    imageRender.sprite = images[0];
                    break;
                }
            case "face":
                {
                    imageRender.sprite = images[1];
                    break;
                }
            case "mask":
                {
                    imageRender.sprite = images[2];
                    break;
                }
        }
    }
}
