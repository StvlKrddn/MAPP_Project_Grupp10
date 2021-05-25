using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuHIghScore : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Highscore: " + PlayerPrefs.GetInt("HighScore") + " bananas collected";
    }
}