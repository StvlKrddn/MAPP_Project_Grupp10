using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolymeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider; 

    void Start()
    {
       musicSlider.value = PlayerPrefs.GetFloat("Music", musicSlider.value);
       sfxSlider.value = PlayerPrefs.GetFloat("SoundFX", sfxSlider.value);

   }
   
   private void OnDisable(){
       PlayerPrefs.SetFloat("Music", musicSlider.value);
       PlayerPrefs.SetFloat("SoundFX", sfxSlider.value);
   }

   public void SetMusic(float volume){
     audioMixer.SetFloat("Music", volume);
   }

   public void SetSoundFx(float volume){
       audioMixer.SetFloat("SoundFX", volume);
   }
}
