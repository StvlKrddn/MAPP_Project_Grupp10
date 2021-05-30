using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MusicPlayer : MonoBehaviour
{   

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip musicClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicClip;

        audioSource.loop = true;

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
