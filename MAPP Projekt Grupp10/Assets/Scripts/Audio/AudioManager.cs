using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    
    static System.Random rnd = new System.Random();

    public AudioSource menyAudioMixer; 

    void Awake()
    {
        // Ser till att endast en instans av AudioManager finns samtidigt
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // G�r s� att ljuden inte avbryts mellan scener

        foreach (Sound s in sounds) // F�r varje ljud som har lagts till i inspektorn.
        {
            s.source = gameObject.AddComponent<AudioSource>(); // L�gger till en AudioSource-komponent i AudioManager
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = menyAudioMixer.GetComponent<AudioSource>().outputAudioMixerGroup;
        }
    }

    /// <summary>
    /// Spelar upp ett ljud, kan vara loopande eller "One-shot"
    /// </summary>
    /// <param name="name">Namnet p� ljudet. Sattes i inspektorn under AudioManager</param>
    public void Play (string name) // Anv�nd denna metod vart som helst i andra scripts f�r att spela ett ljud, exempel: FindObjectOfType<AudioManager>().Play("[NAMN P� LJUD]");
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // H�mtar ljudet fr�n arrayen efter namnet som skickades in
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "not found, did you call the right name?");
            return;
        }
        if (s.randomizePitch)
            s.source.pitch = RandomNumberGenerator(s.minPitch, s.maxPitch); // S�tter en slumpm�ssig pitch p� ljudet varje g�ng det spelas
        s.source.Play(); // Spelar ljudet
    }

    private float RandomNumberGenerator(float min, float max)
    {
        float number = (float)rnd.NextDouble() * (max - min) + min;
        number = (float)decimal.Round((decimal)number, 1);
        return number;
    }
}
