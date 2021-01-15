using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    public GameObject[] digits;
    public GameObject red;
    public GameObject green;
    public Scene currentScene;    
    private int[] inputNumbers;
    private int index = 0;
    private float timer = 0;
    private int state = 0;

    public void Start()
    {
        inputNumbers = new int[4];
        currentScene = SceneManager.GetActiveScene();
    }

    public void Update()
    {
        if (state != 0)
        {
            if (state == 1)
            {
                //if(currentScene.name == "Start")
                //{
                //    //SceneManager.LoadSceneAsync("1st_Floor");
                //}
                //else if(currentScene.name == "1st_Floor")
                //{
                //    //SceneManager.LoadSceneAsync("MenuUI");
                //}
                SceneLoader.Progress();
            }
            else if (timer < 1)
            {
                red.SetActive(true);
                timer += Time.deltaTime;
            }
            else
            {
                TextMeshProUGUI text;
                foreach (GameObject item in digits)
                {
                    text = item.GetComponent<TextMeshProUGUI>();
                    text.SetText("" + 0);
                    red.SetActive(false);
                    green.SetActive(false);
                }
                red.SetActive(false);
                timer = 0;
                state = 0;
            }
        }
    }
    public void DigitInput(int num)
    {
        TextMeshProUGUI text; 
        if (index == 0)
        {
            state = 0;
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
            if (inputNumbers[0] == 1 && inputNumbers[1] == 1 && inputNumbers[2] == 2 && inputNumbers[3] == 3 && currentScene.name == "Start")
            {
                state = 1;
            }
            else if(inputNumbers[0] == 1 && inputNumbers[1] == 1 && inputNumbers[2] == 1 && inputNumbers[3] == 1 && currentScene.name == "1st_Floor")
            {
                state = 1;
            }
            else
            {
                state = 2;
            }
            index= 0;
        }
        else
        {
            index++;
        }
    }
    
    public void ExitKeypad()
    {
        transform.gameObject.SetActive(false);
    }
}
