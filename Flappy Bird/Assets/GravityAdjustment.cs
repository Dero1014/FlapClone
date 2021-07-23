/*
 * Made to speed up player falling 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAdjustment : MonoBehaviour
{
    public float FallModifier;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (_rb.velocity.y < 0) // Which means if it is falling
            _rb.velocity += Vector2.up * Physics2D.gravity.y * FallModifier * Time.deltaTime; // Beacues we just want a fraction of a second where that frame is

    }
}
