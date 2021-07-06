using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce;

    private Rigidbody2D _rb;

    private bool _jump = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        bool jumpPressed = Input.GetMouseButtonDown(0);
        if (jumpPressed) _jump = true;
    }

    private void FixedUpdate()
    {
        Jump(_jump);
    }

    void Jump(bool jump)
    {
        if (jump)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            _jump = false;
        }
    }

    public void DisableRigidbody()
    {
        _rb.simulated = false;
    }

    public void EnableRigidbody()
    {
        _rb.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("I be ded");
        //play death animation
        //restart
    }

}
