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
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ResumeGame);
        audioSource = GetComponent<AudioSource>();
    }

    public void ResumeGame()
    {
        
        StartCoroutine("WaitForAnimation");
        
        //HideMenu();
    }

    public void PlayClickSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1);
        audioSource.PlayOneShot(clickSound, 0.5f);
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
