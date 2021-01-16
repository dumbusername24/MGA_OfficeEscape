using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFinalTime : MonoBehaviour
{
    private void Awake()
    {
        if (Timer.seconds < 10)
        {
            this.GetComponent<TextMeshProUGUI>().SetText(Timer.minutes + ":0" + Timer.seconds);
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().SetText(Timer.minutes + ":" + Timer.seconds);
        }
        Timer.SaveGame();
        Timer.Reset();
    }
    
}
