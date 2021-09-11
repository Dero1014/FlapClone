/*========================================================================*/
/*  This script is used as a base and to control UI elements of the game  */
/*========================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public event Action GameStart;
    public event Action Options;

    [SerializeField]
    private Image _tapIcon;
    [SerializeField]
    private Sprite _clickImg;

    private DeviceType _dType;

    [SerializeField]
    private AudioSource[] sources;

    /*  Singleton start */
    public static UIScript instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    private void Start()
    {
        ImageSwitch();
    }

    private void ImageSwitch()
    {
        _dType = SystemInfo.deviceType;

        if (_dType != DeviceType.Handheld)
        {
            // Switch out with the mouse img
            _tapIcon.sprite = _clickImg;
        }
    }

    public void StartGame()
    {
        GameStart?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOptions()
    {
        sources = GameObject.FindObjectsOfType<AudioSource>();
        Options?.Invoke();
    }

    public void OnVolumeChange(Slider slider)
    {
        foreach (AudioSource source in sources)
        {
            source.volume = slider.value;
        }
    }

}
