/*=================================================================================================================*/
/*  This script generates a bunch of obstacles, disables them and calls them out whenever needed in other scripts  */
/*=================================================================================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private int _numberOfObjects;

    private Queue<GameObject> _prefabCollection = new Queue<GameObject>();

    /*  Singleton start */
    public static ObstaclePooling instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        GeneratePool();    
    }

    // First we generate a pool of objects and add them to the collection
    void GeneratePool()
    {
        for (int i = 0; i < _numberOfObjects; i++)
        {
            AddToPool(Instantiate(_prefab));
        }
    }

    // Then we alow anyone to use the Add and Remove method for pooling
    public void AddToPool(GameObject obj)
    {
        obj.SetActive(false);
        _prefabCollection.Enqueue(obj);
    }

    public GameObject RemoveFromPool()
    {
        GameObject obj = _prefabCollection.Dequeue();
        obj.SetActive(true);
        return obj;
    }

}
