using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTutorialButton : MonoBehaviour
{
    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {

        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();

        if (PlayerPrefs.GetInt("TutorialEnabled") == 0)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            playerState.isTutorialEnabled = true;
        }
        else {
            gameObject.GetComponent<Toggle>().isOn = false;
            playerState.isTutorialEnabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTutorialOn(bool newValue)
    {
        playerState.isTutorialEnabled = newValue;
        if (newValue == true)
        {
            PlayerPrefs.SetInt("TutorialEnabled", 0);
        }
        else
        {
            PlayerPrefs.SetInt("TutorialEnabled", 1);
        }
    }

}
