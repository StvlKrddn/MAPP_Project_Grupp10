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

    void Awake(){
        panels.Add(creditsPanel);
        panels.Add(menyPanel);
        panels.Add(settingsPanel);
    }
    public void startGame(int level){
        SceneManager.LoadScene(level);
    }
    public void openPanel(GameObject gameObject){
        foreach(GameObject g in panels){
            if(g.Equals(gameObject)){
                g.SetActive(true);
            } else {
                g.SetActive(false);
            }
        }

    }

}
