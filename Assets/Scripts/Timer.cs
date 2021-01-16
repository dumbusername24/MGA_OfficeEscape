using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timerObject;
    private TextMeshProUGUI timer;
    private float time = 0;
    private int seconds = 0;
    private int minutes = 0;
    static public bool timerOnOff = true;

    private void Start()
    {
        timer = timerObject.GetComponent<TextMeshProUGUI>();
        timerOnOff = true;
    }
    void Update()
    {
        if (timerOnOff)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                seconds++;
                time -= 1;
            }
            if (seconds % 60 == 0 && seconds != 0)
            {
                seconds = 0;
                minutes++;
            }
            if (seconds < 10)
            {
                timer.SetText(minutes + ":0" + seconds);
            }
            else
            {
                timer.SetText(minutes + ":" + seconds);
            }
        }
    }
}
