/*===================================================================================*/
/*  This script is used for obstacle movement and reserting back into obstacle pool  */
/*===================================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _speedModifier;
    [SerializeField]
    private float _returnDistance;

    void FixedUpdate() 
    {
        // Even if it isn't really a rigidbody anything that will eventually collide with a rigidbody has to have a
        // fixed update if it will
        // Result: Smoother interaction between the player and the obstacle
        if (GameManager.instance.ObstacleMovement)
        {
            transform.Translate(Vector3.left * _speedModifier);
        }
    }

    private void Update()
    {
        // The minus is used to signify the negative distance the obstacle moves in
        if (transform.position.x < -_returnDistance)
            ObstaclePooling.instance.AddToPool(gameObject);
    }

}
