/*====================================================================*/
/*  This script holds player actions to be executed on input command  */
/*====================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : PlayerComponents
{
    public event Action OnDeath;
    public event Action OnScoreGain;

    [SerializeField]
    private float JumpForce;

    private bool _jump = false;

    /*  Singleton start */
    public static PlayerActions instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        PlayerInputSystem.instance.JumpInput += Jump;
    }

    void FixedUpdate()
    {
        Jumpy(_jump);
        _jump = false;
    }

    void Jump()
    {
        _jump = true;
    }

    void Jumpy(bool jump)
    {
        if (jump)
        {
            _rb.velocity = Vector2.zero; // to keep a constant jump height
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeath?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnScoreGain?.Invoke();
    }

}
