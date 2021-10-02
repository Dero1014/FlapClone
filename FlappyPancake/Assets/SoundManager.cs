﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundList
{
    public AudioClip clip;
    public AudioSource source;
    [Range(0,1)]
    public float volume;
    public string name;
}

public class SoundManager : MonoBehaviour
{

    [HideInInspector]
    public SoundList[] SList;

    /*  Singleton start */
    public static SoundManager instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        foreach (SoundList s in SList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            // Add the new source to the settings class

            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play(string Sound)
    {
        foreach (SoundList sound in SList)
        {
            if (sound.name == Sound)
            {
                sound.source.Play();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            GameSettings.current.VSettings.Sources = GameObject.FindObjectsOfType<AudioSource>();

            print("KeyPressed");
        }
    }

}
