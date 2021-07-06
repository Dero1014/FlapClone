using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnTime;

    private float _timer;

    void Start()
    {
        //set off the spawn as soon as it starts
        _timer = SpawnTime;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= SpawnTime)
        {
            //rand pos thingyyy
            Vector3 randPosition = transform.position;
            randPosition.y += Random.Range(-2.5f, 2.5f);

            //spawns obstacle
            Instantiate(Prefab, randPosition, Quaternion.identity);
            _timer = 0;
        }

    }
}
