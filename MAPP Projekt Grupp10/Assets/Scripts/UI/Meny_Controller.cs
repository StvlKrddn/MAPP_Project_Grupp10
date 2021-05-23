using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Meny_Controller : MonoBehaviour
{
    [SerializeField] private GameObject menyPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    private List<GameObject> panels = new List<GameObject>();

    private LevelLoader levelLoader;

    private AudioSource audiSource;
    public AudioClip clickSound;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        audiSource = GetComponent<AudioSource>();
    }

    void Awake(){
        panels.Add(creditsPanel);
        panels.Add(menyPanel);
        panels.Add(settingsPanel);
    }
    public void startGame(int level){
        PlayClickSound(clickSound);
        levelLoader.LoadNextLevel(level);
    }
    public void openPanel(GameObject gameObject){
        foreach(GameObject g in panels){
            if(g.Equals(gameObject)){
                PlayClickSound(clickSound);
                g.SetActive(true);
            } else {
                g.SetActive(false);
            }
        }

    }


    private void PlayClickSound(AudioClip clip)
    {
        audiSource.pitch = Random.Range(0.8f, 1);
        audiSource.PlayOneShot(clip, 0.5f);
    }

}
