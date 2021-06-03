using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    TMP_Text liveText;
    bool status;

    public string OriginalText, AlternateTest;

    private void Start()
    {
        liveText = this.GetComponent<TMP_Text>();
        liveText.text = OriginalText;
        status = true;  
    }
    public void changeText()
    {
        status = !status;
        if (status) liveText.text = OriginalText;
        else liveText.text = AlternateTest;
    }
}
