using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonResumeGame : MonoBehaviour
{

    private Button button;
    public Button pauseButton;
    [SerializeField] private GameObject menu;
    [SerializeField] private Animator canvasAnimator;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ResumeGame);
    }

    public void ResumeGame()
    {
        
        StartCoroutine("WaitForAnimation");
        
        //HideMenu();
    }

    public void HideMenu()
    {

        menu.SetActive(false);
    }

    IEnumerator WaitForAnimation()
    {
        canvasAnimator.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        pauseButton.interactable = true;
    }

}
