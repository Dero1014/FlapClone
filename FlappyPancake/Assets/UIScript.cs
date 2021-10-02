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

[Serializable]
public class ObjectData
{
    public string name;
    public bool active;
}

public class UIScript : MonoBehaviour
{
    public event Action GameStart;
    public event Action OnRestart;
    public event Action Options;

    [SerializeField]
    private Image _tapIcon;
    [SerializeField]
    private Sprite _clickImg;

    private DeviceType _dType;

    /*  Singleton start */
    public static UIScript instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    //Rework aditions
    [SerializeField]
    private GameObject ScorePanel; 

    private void Start()
    {
        ImageSwitch();
    }

    //Changes the tap image from a tap  to a click based on the device type
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

    public void EnableInput()
    {
        PlayerInputSystem.instance.enabled = true;
    }

    public void StartHighScore()
    {
        // add animation later
        if (ScorePanel !=null)
            ScorePanel.SetActive(true);
        else
            Debug.LogError("You fucked up you need to add a score panel");
    }

    public void Restart()
    {
        OnRestart?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOptions()
    {
        Options?.Invoke();
    }


    public void ButtonPress()
    {
        SoundManager.instance.Play("Press");
    }

}
