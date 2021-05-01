using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoadLevel : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int levelToLoad = 0;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(loadNewLevel);
    }

    public void loadNewLevel()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(levelToLoad);
    }


}
