/*============================================================*/
/*  This script controls the spawning rates of the obstacles  */
/*============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField]
    private float _spawnTimer;
    private float _timer;
    [SerializeField]
    private int _range;

    private void Start()
    {
        // To instantly start spawning the first obj
        _timer = _spawnTimer;
    }

    void Update()
    {
        Spawn(SpawnTimer());
    }

    // Timer that allows the Spawner to spawn one obj
    bool SpawnTimer()
    {
        _timer += Time.deltaTime;
        return (_timer >= _spawnTimer);
    }

    void Spawn(bool spawn)
    {
        if (spawn)
        {
            int randomYPosition = Random.Range(-_range, _range);
            GameObject obj = ObstaclePooling.instance.RemoveFromPool();
            obj.transform.position = new Vector2(transform.position.x, randomYPosition);
            _timer = 0;  // Reset timer
        }
    }

}
