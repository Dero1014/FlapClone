/*
 * This script handles the UI elements of the games, starting it, restarting it ect.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
struct GameCondition
{
    public bool startGame;
    public bool tap;
}


public class UIScript : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject TapPanel;
    public GameObject RestartPanel;

    private PlayerInput _pi;
    private ObstacleGenerator _og;
    
    private GameCondition _gc;

    void Awake()
    {
        // Since its a special script its the only existing script
        _pi = FindObjectOfType<PlayerInput>();
        _pi.enabled = false;

        // Obstacle
        _og = FindObjectOfType<ObstacleGenerator>();
        _og.enabled = false;
    }

    void Update()
    {
        StartGameFcn();
    }

    void StartGameFcn()
    {
        if (_gc.startGame)
        {
                // Remove the start Screen
            RemoveStart();

                // Show the tap screen is located in SpecialUIScript.cs
            // ShowTap();

                // Enable player inputs
            EnableInput();
            _gc.startGame = false;
        }
    }

    // Removes the Start panel with an animation that dissables it
    void RemoveStart()
    {
        Animator startAnimator = StartPanel.GetComponent<Animator>();
        startAnimator.SetBool("Start", _gc.startGame);
    } 

    void EnableInput()
    {
        _pi.enabled = true;
    }

    public void StartGame()
    {
        _gc.startGame = true;
    }

    public void Tap()
    {
        if (!_gc.tap)
        {
            _gc.tap = true;
            _og.enabled = true;
            TapPanel.GetComponent<Animator>().SetBool("Tap", true);
            _pi.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    public void Dead()
    {
        RestartPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
