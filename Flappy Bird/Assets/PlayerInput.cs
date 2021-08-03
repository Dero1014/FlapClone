/*
 * This script deals with the input of the player which is just the mouse button
 * and calls the jump action from script PlayerAction.cs
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

    PlayerActions _pa;

    private void Start()
    {
        _pa = GetComponent<PlayerActions>();
    }

    void Update()
    {

        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            // Call the jump function
            // _pa.Jump() - calling it directly will not sync the input with the physics correctly better option
            // is to call a function that starts the jumping process in the PlayerActions.cs script
            _pa.Jump();
            GameObject.FindObjectOfType<UIScript>().Tap();
        }       
    }
}
