using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerMain : MonoBehaviour
{
    //consider making the audio manager a prefab
    public SoundMain[] sounds;
    public static AudioManagerMain instance;

    // Awake is called before Start
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (SoundMain singleSound in sounds)
        { 
            singleSound.source = gameObject.AddComponent<AudioSource>();
            singleSound.source.clip = singleSound.clip;
            singleSound.source.volume = singleSound.volume;
            singleSound.source.loop = singleSound.loop;
        }
    }

    public void Play(string name)
    {
        SoundMain s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound by Name: " + name + "was not found!");
            return;
        }
        s.source.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("BackgroundMusic");
    }
}
