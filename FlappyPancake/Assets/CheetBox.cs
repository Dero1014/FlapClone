/*=======================================================================*/
/*  This script is a testing tool for player fluid and juice in jumping  */
/*=======================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetBox : PlayerComponents
{
    public bool AutoClick;
    public bool JumpTimer;

    private Vector3 _position;
    private Vector3 _jumpPosition;

    public float _time=0;

    private bool _jumped = false;
    private bool _jumpRecorded = false;

    void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        AutoClicker();
        JumpHeight();
        Timer();
    }

    private void Timer()
    {
        if (JumpTimer)
        {
            if (_rb.velocity.y > 0)
            {
                _time += Time.deltaTime;
            }
            else if(_jumped)
            {
                print($"Jump time is: {_time * 2}");
                _time = 0;
            }
        }
    }

    private void JumpHeight()
    {
        if (_rb.velocity.y < 0 && !_jumpRecorded)
        {
            //record height - difference from jump to max height
            print($"Player jump height was : {transform.position.y - _jumpPosition.y}");
            _jumpRecorded = true;
        }
        else if (_rb.velocity.y > 0 && _jumpRecorded)
        {
            _jumpRecorded = false;
        }
    }

    private void AutoClicker()
    {
        if (AutoClick)
        {
            if (transform.position.y <= _position.y && !_jumped)
            {
                // then jump
                PlayerInputSystem.instance.JumpTest();
                _jumpPosition = transform.position;
                _jumped = true;
            }
            else if (transform.position.y > _position.y && _jumped)
            {
                _jumped = false;
            }
        }

    }
}
