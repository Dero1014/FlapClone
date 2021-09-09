/*============================================================*/
/*  This script controls the game by setting up its modifiers */
/*============================================================*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _startGame = false;
    [HideInInspector]
    public bool SpawnEnabled = false;
    private bool _gameTapped = false;
    private bool _playerDead = false;
    [HideInInspector]
    public bool ObstacleMovement = true;
    [HideInInspector]
    public bool GroundAnimation = true;

    /*  Singleton start */
    public static GameManager instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        UIScript.instance.GameStart += StartGame;
        PlayerInputSystem.instance.JumpInput += TappedGame;
        PlayerActions.instance.OnDeath += PlayerDead;
    }

    void StartGame()
    {
        _startGame = true;
        // ENABLE INPUT - Input enabled in StartUI.cs line 25
    }

    void TappedGame()
    {
        _gameTapped = true;

        // ENABLE PHYSICS
        PlayerComponents._rb.simulated = true;
        PlayerInputSystem.instance.JumpInput -= TappedGame;
        // ENABLE SPAWNING - Spawning enabled with _gameTapped in ObstacleSpawn.cs line 25
        SpawnEnabled = true;
    }

    void PlayerDead()
    {
        _playerDead = true;
        // STOP PLAYER INPUT
        PlayerInputSystem.instance.enabled = false;

        // STOP SPAWNING - Spawning enabled with _gameTapped in ObstacleSpawn.cs line 25
        SpawnEnabled = false;

        // STOP OBSTACLE MOVEMENT - Obstacle Movement disabled with ObstacleMovement in Obstacle.cs line 21 
        ObstacleMovement = false;

        // STOP BACKGROUND MOVEMENT - Ground movement disabled with GroundAnimation in GroundAnimation.cs line 49  
        GroundAnimation = false;

        // STOP PLAYER PHYSICS
        PlayerComponents._rb.simulated = false;

    }
}
