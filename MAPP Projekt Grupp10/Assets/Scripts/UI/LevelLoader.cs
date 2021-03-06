using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;
    public Animator transition;

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }


}
