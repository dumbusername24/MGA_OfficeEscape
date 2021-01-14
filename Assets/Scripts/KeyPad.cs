using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public GameObject[] Digits;
    private int index = 0;
    public void DigitInput(int num)
    {
        TextMeshProUGUI text = Digits[index].GetComponent<TextMeshProUGUI>();
        text.SetText("" + num);
        if (index >= 3)
        {
            index= 0;
        }
        else
        {
            index++;
        }
    }
    
}
