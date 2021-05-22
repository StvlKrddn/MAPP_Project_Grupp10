using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseGame : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject menu;
    [SerializeField] private Animator canvasAnimator;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PauseGame);
    }

    public void PauseGame()
    {
        canvasAnimator.SetTrigger("Open");
        Time.timeScale = 0;
        //ShowMenu();
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
