/*=======================================================*/
/*  This script controls the animators inside UI panels  */
/*=======================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator StartAnimator;
    [SerializeField]
    private Animator TapAnimator;
    private Animator RestartAnimator;

    private void Start()
    {
        UIScript.instance.GameStart += StartAnimation;
        PlayerInputSystem.instance.JumpInput += TapAnimation;
    }

    void StartAnimation()
    {
        StartAnimator.SetTrigger("End");
    }

    void TapAnimation()
    {
        TapAnimator.SetTrigger("End");
    }

    void RestartAnimation()
    {

    }


}
