using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHighScore : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        if (PlayerPrefs.GetInt("HighScore") >= PlayerPrefs.GetInt("BananasCollected"))
        {
            text.text = "High Score: " + PlayerPrefs.GetInt("HighScore") + " bananas";
        }

        else if (PlayerPrefs.GetInt("BananasCollected") > PlayerPrefs.GetInt("HighScore"))
        {
            text.text = "New High Score : " + PlayerPrefs.GetInt("BananasCollected") + " bananas";

            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("BananasCollected"));

        }

    }
}




