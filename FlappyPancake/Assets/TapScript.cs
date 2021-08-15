/*=======================================================================*/
/*  This script is part of UIScript.cs and is used for animation events  */
/*=======================================================================*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour
{
    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
