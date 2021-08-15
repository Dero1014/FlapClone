/*========================================*/
/*  This script holds player components   */
/*========================================*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [HideInInspector]
    public static Rigidbody2D _rb;

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
}
