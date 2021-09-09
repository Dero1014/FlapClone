/*==============================================================*/
/*  This script creates so the ground moves the same speed as   */
/*  the obstacles                                               */
/*==============================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAnimation : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [Space(10)]
    [SerializeField]
    private Transform _start;
    [SerializeField]
    private Transform _end;

    private Vector2 _startPosition;
    private Vector2 _endPosition;

    void Start()
    {
        _startPosition = _start.position;
        _endPosition = _end.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveSprites();
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (_start.position.x <= -13.5f)
        {
            _start.position = _startPosition;
            _end.position = _endPosition;
        }
    }

    private void MoveSprites()
    {
        if (GameManager.instance.GroundAnimation)
        {
            _start.Translate(Vector2.left * _speed);
            _end.Translate(Vector2.left * _speed);
        }
    }
}
