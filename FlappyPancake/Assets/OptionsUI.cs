/*=======================================================================*/
/*  This script controls the audio for the game by following             */
/*  OnValueChange from the Slider                                        */
/*=======================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    private Slider _slider;
    private float _currentVolume = 0;


    private void Start()
    {
        _currentVolume = SaveData.current.Settings.volume;
        _slider = GetComponentInChildren<Slider>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        _slider.value = _currentVolume;
    }

    public void OnVolumeChange()
    {
        SaveData.current.Settings.volume = _slider.value;
        GameSettings.current.VSettings.ChangeVolume(_slider.value);
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
