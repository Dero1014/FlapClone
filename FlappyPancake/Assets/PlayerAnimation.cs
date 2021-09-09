using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _animator;

    private bool _oS = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        PlayerInputSystem.instance.JumpInput += JumpAnim;
    }

    void JumpAnim()
    {
        _animator.SetTrigger("Jump");
    }
}
