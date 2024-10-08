﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundList
{
    public AudioClip clip;
    public AudioSource source;
    public string name;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private SoundList[] SList;

    /*  Singleton start */
    public static SoundManager instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        foreach (SoundList s in SList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
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
}
