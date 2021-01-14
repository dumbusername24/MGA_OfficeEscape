using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public GameObject[] digits;
    public GameObject red;
    public GameObject green;
    private int[] inputNumbers;
    private int index = 0;

    public void Start()
    {
        inputNumbers = new int[4];
    }
    public void DigitInput(int num)
    {
        TextMeshProUGUI text; 
        if (index == 0)
        {
            foreach (GameObject item in digits)
            {
                text = item.GetComponent<TextMeshProUGUI>();
                text.SetText("" + 0);
                red.SetActive(false);
                green.SetActive(false);
            }
        }
        text = digits[index].GetComponent<TextMeshProUGUI>();
        text.SetText("" + num);
        inputNumbers[index] = num;
        if (index >= 3)
        {
            if (inputNumbers[0] == 1 && inputNumbers[1] == 1 && inputNumbers[2] == 1 && inputNumbers[3] == 1)
            {
                green.SetActive(true);
            }
            else
            {
                red.SetActive(true);
            }
            index= 0;
        }
        else
        {
            index++;
        }
    }
    
}
