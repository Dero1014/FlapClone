using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObstacleGenerator _og;
    public PlayerController _player;

    private bool _startGame;

    void Start()
    {
        _og = FindObjectOfType<ObstacleGenerator>();
        _player = FindObjectOfType<PlayerController>();

        _og.enabled = false;
        _player.DisableRigidbody();
        _player.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.enabled = true;
            _player.EnableRigidbody();
            _og.enabled = true;
        }
    }
}
