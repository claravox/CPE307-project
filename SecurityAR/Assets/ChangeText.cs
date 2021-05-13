using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    TMP_Text liveText;
    bool status;
    private void Start()
    {
        liveText = this.GetComponent<TMP_Text>();
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
