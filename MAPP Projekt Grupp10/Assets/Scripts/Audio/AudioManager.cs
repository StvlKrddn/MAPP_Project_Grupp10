using UnityEditor.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public AudioClip[] playerHurtSounds;
    public int clipIndex;
    public AudioSource playerHurtSource;

    public static AudioManager instance;
    
    static System.Random rnd = new System.Random();

    // Start is called before the first frame update
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

    public void PlayPlayerHurtSound() // Anv�nds n�r spelaren tar skada
    {
        /*if (clipIndex < playerHurtSounds.Length)
        {
            playerHurtSource.PlayOneShot(playerHurtSounds[clipIndex]);
            clipIndex++;
        }
        else
        {
            clipIndex = 0;
            playerHurtSource.PlayOneShot(playerHurtSounds[clipIndex]);
            clipIndex++;
        }*/
        clipIndex = RepeatCheck(clipIndex, playerHurtSounds.Length);
        playerHurtSource.PlayOneShot(playerHurtSounds[clipIndex]);
    }

    private int RepeatCheck(int preciousIndex, int range)
    {
        int index = rnd.Next(0, range);
        while (index == preciousIndex)
            index = rnd.Next(0, range);
        return index;
    }

    

    private float RandomNumberGenerator(float min, float max)
    {
        float number = (float)rnd.NextDouble() * (max - min) + min;
        number = (float)decimal.Round((decimal)number, 1);
        return number;
    }
}
