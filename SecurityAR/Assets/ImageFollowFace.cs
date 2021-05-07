using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFollowFace : MonoBehaviour
{
    FaceDetector faceDetector;

    // Start is called before the first frame update
    void Start()
    {
        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(faceDetector.transform.position.x - 180 + faceDetector.FaceX, faceDetector.transform.position.y + 110 - 1 * faceDetector.FaceY, transform.position.z);
        
    }
}
