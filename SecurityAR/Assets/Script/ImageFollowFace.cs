using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rect = OpenCVForUnity.CoreModule.Rect;
using OpenCVForUnity.CoreModule;
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
        //imageRender.enabled = false;
        cameraView = GameObject.Find("CameraView");
    }

    // Update is called once per frame
    void Update()
    {
        float x = cameraView.transform.position.x - cameraView.GetComponent<RectTransform>().rect.width * cameraView.GetComponent<RectTransform>().localScale.x / 2 + faceLocation.x + faceLocation.width / 2;
        float y = cameraView.transform.position.y + cameraView.GetComponent<RectTransform>().rect.height * cameraView.GetComponent<RectTransform>().localScale.y / 2 - faceLocation.y - faceLocation.height/2;
        float x_scale = faceLocation.width / 100.0f;
        float y_scale = faceLocation.height / 100.0f; 
        float resScale = 1.0f;
        if (faceLocation.width >= faceLocation.height)
            resScale = x_scale * 1.3f;
        else
            resScale = y_scale * 1.3f;

        facePos = new Vector3(x, y, transform.position.z);
        newScale = new Vector3(resScale, resScale, 1);
        this.GetComponent<RectTransform>().localScale = Vector3.Lerp(this.GetComponent<RectTransform>().localScale, newScale, Time.deltaTime*5);
        this.transform.position = Vector3.Lerp(transform.position, facePos, Time.deltaTime*3);
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
