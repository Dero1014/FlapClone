/*
 * Script for moving obstacles and removing them after a certian distance
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float Speed;
    public float XVectorDepth;

    void Update()
    {
        transform.Translate(new Vector3(-Speed, 0, 0));
        CheckDistance();
    }

    void CheckDistance()
    {
        if (transform.position.x < XVectorDepth)
        {
            PoolingScript.Instance.AddToPool(gameObject);
        }
    }
}
