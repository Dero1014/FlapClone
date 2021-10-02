/*=======================================================*/
/*  This script controls the animators inside UI panels  */
/*=======================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator UIAnimator;

    private void Start()
    {
        //Animator
        UIAnimator = GetComponent<Animator>();

        //Events
        UIScript.instance.GameStart += StartAnimation;
        UIScript.instance.Options += OptionsAnimations;
        UIScript.instance.OnRestart += BlackScreen;
        PlayerInputSystem.instance.JumpInput += TapAnimation;
        PlayerActions.instance.OnDeath += RestartAnimation;

        //Options

    }

    void StartAnimation()
    {
        //end start panel
        UIAnimator.SetTrigger("Start Game");
    }

    void TapAnimation()
    {
        //End tap panel
        UIAnimator.SetTrigger("Tapped");
    }

    void RestartAnimation()
    {
        // Start game over animation
        UIAnimator.SetTrigger("Death");
    }
    
    void BlackScreen()
    {
        UIAnimator.SetTrigger("Restart");
    }

    bool options = false;
    void OptionsAnimations()
    {
        options = !options;
        UIAnimator.SetBool("Options", options);
    }
}
