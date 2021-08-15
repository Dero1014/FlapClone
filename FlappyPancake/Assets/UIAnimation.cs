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
    [SerializeField]
    private GameObject RestartAnimator;
    [SerializeField]
    private GameObject HighScoreAnimator;

    private void Start()
    {
        UIScript.instance.GameStart += StartAnimation;
        PlayerInputSystem.instance.JumpInput += TapAnimation;
        PlayerActions.instance.OnDeath += RestartAnimation;
        PlayerActions.instance.OnDeath += HighScorePanel;
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
        // We use game object since it will only turn on the one animation as the object is turned on
        RestartAnimator.SetActive(true);
    }

    void HighScorePanel()
    {
        // add animation later
        HighScoreAnimator.SetActive(false);
    }

}
