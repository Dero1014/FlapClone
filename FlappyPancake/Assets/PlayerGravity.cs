/*============================================================*/
/*  This script controls the gravity modifier on the player   */
/*============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : PlayerComponents
{
    [SerializeField]
    private float _gravityMultiplyer;
    private void Start()
    {
        
    }

    void Update()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity * _gravityMultiplyer * Time.deltaTime;
        }
    }
}
