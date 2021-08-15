/*====================================================================*/
/*  This script holds player actions to be executed on input command  */
/*====================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : PlayerComponents
{
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

}
