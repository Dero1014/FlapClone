using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class VolumeSettings 
{
    public AudioSource[] Sources;

    public VolumeSettings()
    {
    }

    public void ChangeVolume(float value)
    {
        foreach (AudioSource source in Sources)
        {
            source.volume = value;
        }
    }
    
}
