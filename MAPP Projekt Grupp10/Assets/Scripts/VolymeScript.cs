using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolymeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
   private void OnDisable(){
       PlayerPrefs.SetFloat("Music", musicSlider.value);
       PlayerPrefs.SetFloat("SoundFX", sfxSlider.value);
   }

   public void SetToggleMusic(bool enableSound){
       if(enableSound) 
            musicSlider.value = 0;
        else
            musicSlider.value = -80;
   }
   public void SetToggleSFX(bool enableSound){
        if(enableSound) 
            sfxSlider.value = 0;
        else
            sfxSlider.value = -80;     
   }

   public void SetMusic(float volume){
     audioMixer.SetFloat("Music", volume);
   }

   void Start(){
       musicSlider.value = PlayerPrefs.GetFloat("Music", musicSlider.value);
       sfxSlider.value = PlayerPrefs.GetFloat("SoundFX", sfxSlider.value);

   }

   public void SetSoundFx(float volume){
       audioMixer.SetFloat("SoundFX", volume);
   }
}
