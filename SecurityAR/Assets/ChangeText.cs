using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    Text liveText;
    bool status;
    private void Start()
    {
        liveText = this.GetComponent<Text>();
        liveText.text = "ON";
        status = true;  
    }
    public void changeTextForLiveMode()
    {
        status = !status;
        if (status) liveText.text = "ON";
        else liveText.text = "OFF";
    }
}
