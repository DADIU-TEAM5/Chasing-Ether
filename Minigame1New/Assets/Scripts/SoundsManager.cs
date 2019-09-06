using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public Sound[] sounds;
    public static SoundsManager instance;
    // Start is called before the first frame update
    private float soundvolume;
    private float dynamicIncrease;
  

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //if you want a continuous background
        //DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        
    }

    //use this as FindObjectOfType<AudioManager>().Play("SoundsName");
    public void PlaySounds(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }

        s.source.Play();
    }

    /*
    public void DynamicPlay()
    {

    }
    */
}
