using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer videoPlayer;
    public VideoClip cutScene;
    public LevelLoader levelLoader;
    public int levelIndexToLoad = 1;
    [SerializeField] private float sceneTimeFreeze;

    void Start()
    {
        StartCoroutine("PlayVideo"); 
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Play();
        yield return new WaitForSeconds((float)cutScene.length+sceneTimeFreeze);
        levelLoader.LoadNextLevel(levelIndexToLoad);

    }

}
