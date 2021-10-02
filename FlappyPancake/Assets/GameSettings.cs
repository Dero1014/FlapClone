using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings _current;
    public static GameSettings current
    {
        get
        {
            if (_current == null)
            {
                _current = new GameSettings();
            }
            return _current;
        }
    }

    public VolumeSettings VSettings = new VolumeSettings();

    private void Start()
    {
        VSettings = new VolumeSettings();
        //VSettings.Sources = FindObjectsOfType<AudioSource>();
    }

}
