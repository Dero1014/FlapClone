/*
 * This script handles the jumping ability of the player by taking its rigid body, freezing the velocity
 * and applying the jump force that which can be set by the developer
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float JumpForce;
    private Rigidbody2D _rb;

    private bool _jump = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        JumpPhysics(_jump);
        ResetBools();
    }

    // Sets the jump functionality ON
    public void Jump()
    {
        _jump = true;
    }

    void JumpPhysics(bool jump)
    {
        if (jump)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            _jump = false;
        }
    }


    // Resets all of the bools for functions
    void ResetBools()
    {
        _jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.simulated = false;
        gameObject.GetComponent<PlayerInput>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = true;
        GameObject.FindObjectOfType<ObstacleGenerator>().enabled = false;
        ObstacleScript[] obs;

        obs = GameObject.FindObjectsOfType<ObstacleScript>();

        foreach (ObstacleScript obstacle in obs)
        {
            obstacle.Speed = 0;
        }

        //play death animation
        //restart
    }

}
