#define TESTING

/*==============================================================*/
/*  This script holds input events to be used by other scripts  */
/*==============================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public event Action JumpInput;
    
    /*  Singleton start */
    public static PlayerInputSystem instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Update()
    {
        Jump();
    }


    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JumpInput?.Invoke();
        }
    }

#if TESTING
    public void JumpTest()
    {
        JumpInput?.Invoke();
    }
#endif

}

