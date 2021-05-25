using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseGame : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject menu;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PauseGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        ShowMenu();
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}