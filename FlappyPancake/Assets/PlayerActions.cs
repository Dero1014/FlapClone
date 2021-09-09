/*====================================================================*/
/*  This script holds player actions to be executed on input command  */
/*====================================================================*/

#define DEBUG

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : PlayerComponents
{
    public event Action OnDeath;
    public event Action OnScoreGain;

    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    [Tooltip("Time to get to maximum height")]
    private float _jumpTime;
    [SerializeField] [Range(0,3)]
    private float _multiplier;

    private float _gravity;
    private float _upVelocity;

    private bool _jump = false;

    /*  Singleton start */
    public static PlayerActions instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        PlayerInputSystem.instance.JumpInput += Jump;
        PlayerJumpSettings();
    }

    private void PlayerJumpSettings()
    {
        // calculate what the gravity and upwards velocity should be in order to get 
        _gravity = (2 * _jumpHeight) / Mathf.Pow(_jumpTime, 2);
        _upVelocity = (2 * _jumpHeight) / _jumpTime;
#if DEBUG
        print($"Gravity: {_gravity}, Jump velocity: {_upVelocity}");
#endif
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        PlGravity();
        Jumpy(_jump);
        _jump = false;
    }

    private void PlGravity()
    {
        _rb.AddForce(Vector2.down * _gravity,ForceMode2D.Force);
    }

    void Jump()
    {
        //Sound the jump 
        SoundManager.instance.Play("Jump");
        _jump = true;
    }

    void Jumpy(bool jump)
    {
        if (jump)
            _rb.velocity = Vector2.up * _upVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeath?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnScoreGain?.Invoke();
        // Sound the point 
        SoundManager.instance.Play("Point");
    }

}
