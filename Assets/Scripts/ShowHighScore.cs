using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScoreSeconds"))
        {
            if (PlayerPrefs.GetInt("HighScoreSeconds") < 10)
            {
                this.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("HighScoreMinutes") + ":0" + PlayerPrefs.GetInt("HighScoreSeconds"));
            }
            else
            {
                this.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("HighScoreMinutes") + ":" + PlayerPrefs.GetInt("HighScoreSeconds"));
            }
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().SetText("No Highscore");
        }
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        Awake();
    }
}
