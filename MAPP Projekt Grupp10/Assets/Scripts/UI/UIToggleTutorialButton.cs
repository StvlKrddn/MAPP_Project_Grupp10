using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTutorialButton : MonoBehaviour
{
    public UiTutorial uiTutorial;
    public bool isTutorialEnabled;

    // Start is called before the first frame update
    void Start()
    {
        

        if (PlayerPrefs.GetInt("TutorialEnabled") == 0)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            isTutorialEnabled = true;
        }
        else {
            gameObject.GetComponent<Toggle>().isOn = false;
            isTutorialEnabled = false;
        }

        if (isTutorialEnabled == true || PlayerPrefs.GetInt("FirstTimePlaying") == 0)
        {
            uiTutorial.StartTutorial();
            PlayerPrefs.SetInt("FirstTimePlaying", 1);
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTutorialOn(bool newValue)
    {
        isTutorialEnabled = newValue;
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
