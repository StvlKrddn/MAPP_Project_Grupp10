using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverBananCollected : MonoBehaviour
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
        text.text = "You collected: " + PlayerPrefs.GetInt("BananasCollected")+ " bananas";
    }
}
