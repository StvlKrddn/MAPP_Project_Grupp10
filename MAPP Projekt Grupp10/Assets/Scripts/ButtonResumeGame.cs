using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonResumeGame : MonoBehaviour
{

    private Button button;
    [SerializeField] private GameObject menu;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ResumeGame);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HideMenu();
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
