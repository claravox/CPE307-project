using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    Camera,
    AboutUs,
    Contact,
    Version
}


public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    public GameObject preview;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.Camera);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }

    public void SetMode(int modeIndex)
    {
        switch (modeIndex)
        {
            case 0:
                {
                    SwitchCanvas(CanvasType.Camera);
                    preview.SetActive(true);
                    break;
                }
            case 1:
                {
                    SwitchCanvas(CanvasType.AboutUs);
                    preview.SetActive(false);
                    break;
                }
            case 2:
                {
                    SwitchCanvas(CanvasType.Contact);
                    preview.SetActive(false);
                    break;
                }
            case 3:
                {
                    SwitchCanvas(CanvasType.Version);
                    preview.SetActive(false);
                    break;
                }
        }
    }
}














