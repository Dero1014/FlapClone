/*
 * Script for spawning obstacles from pool
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float SpawnTime;
    public float RandomRange;
    private float _timer;

    void Start()
    {
        //sets off the spawn as soon as it starts
        _timer = SpawnTime;
    }

    void Update()
    {
        if (Timer())
        {
            //Create a random position on y axis
            Vector3 randPosition = transform.position;
            randPosition.y += Random.Range(-RandomRange, RandomRange);

            //spawns obstacle
            var instance = PoolingScript.Instance.GetFromPool();
            instance.transform.position = randPosition;
            _timer = 0;
        }

    }

    bool Timer()
    {
        _timer += Time.deltaTime;
        return (_timer >= SpawnTime) ? true : false;
    }

}
