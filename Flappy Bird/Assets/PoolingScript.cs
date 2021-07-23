/*
 * This script is used to test out pooling, pooling is the concept ov enableing and disableing objects in order
 * to preserve performance
 */


using UnityEngine;
using System.Collections.Generic;

public class PoolingScript : MonoBehaviour
{
    public int PoolLength = 0;

    [SerializeField]
    private GameObject prefab;

    private Queue<GameObject> _availableGameObjects = new Queue<GameObject>();


    /*      Singleton Start     */
    public static PoolingScript Instance;
    private void Awake()
    {
        Instance = this;
        GrowPool();
    }
    /*      Singleton end       */


    // Returns the first item from the queue and enables it
    public GameObject GetFromPool()
    {
        var instance = _availableGameObjects.Dequeue();
        instance.SetActive(true);

        return instance;
    }


    // Creates items and adds them to the queue
    void GrowPool()
    {
        for (int i = 0; i < PoolLength; i++)
        {
            GameObject clone = Instantiate(prefab, transform);
            AddToPool(clone);
        }
    }

    // Disables items and stores them in the queue 
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        _availableGameObjects.Enqueue(instance);
    }

    void Update()
    {

    }
}
