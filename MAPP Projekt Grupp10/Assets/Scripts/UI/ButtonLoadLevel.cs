using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoadLevel : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int levelToLoad = 0;
    private LevelLoader levelLoader;

    private AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadNewLevel);
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadNewLevel()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        levelLoader.LoadNextLevel(levelToLoad);
    }

    public void PlayClickSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1);
        audioSource.PlayOneShot(clickSound, 0.5f);
    }


}
