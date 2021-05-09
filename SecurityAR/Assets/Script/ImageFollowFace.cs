using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFollowFace : MonoBehaviour
{
    FaceDetector faceDetector;
    GameObject cameraView;
    OpenCvSharp.Rect[] faces;

    // Start is called before the first frame update
    void Start()
    {
        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));
        cameraView = GameObject.Find("CameraView");
    }

    // Update is called once per frame
    void Update()
    {
        faces = faceDetector.Face;
        if (faces.Length < 1)
            return;

        float x = faceDetector.transform.position.x - cameraView.GetComponent<RectTransform>().rect.width / 2 + faces[0].Location.X + faces[0].Width / 2;
        float y = faceDetector.transform.position.y - cameraView.GetComponent<RectTransform>().rect.height / 2 + faces[0].Location.Y - faces[0].Height / 3;
        float x_scale = faceDetector.Face[0].Width / 100.0f;
        float y_scale = faceDetector.Face[0].Height / 100.0f;
        float resScale = 1.0f;
        if (x_scale >= y_scale)
            resScale = x_scale * 1.3f;
        else
            resScale = y_scale * 1.3f;

        Vector3 facePos = new Vector3(x, y, transform.position.z);
        Vector3 newScale = new Vector3(resScale, resScale, 1);
        this.GetComponent<RectTransform>().localScale = Vector3.Lerp(this.GetComponent<RectTransform>().localScale, newScale, Time.deltaTime*5);
        this.transform.position = Vector3.Lerp(transform.position, facePos, Time.deltaTime*3);

    }
}
