using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseGame : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject menu;
    [SerializeField] private Animator canvasAnimator;
    private AudioSource audioSource;
    public AudioSource musicController;
    public AudioClip clickSound;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PauseGame);
        audioSource = GetComponent<AudioSource>();
    }

    public void PauseGame()
    {
        button.interactable = false;
        canvasAnimator.SetTrigger("Open");
        Time.timeScale = 0;
        musicController.Pause();
        //ShowMenu();
    }

    public void PlayClickSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1);
        audioSource.PlayOneShot(clickSound);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
