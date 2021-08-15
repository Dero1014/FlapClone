/*=======================================================================*/
/*  This script is part of UIScript.cs and is used for animation events  */
/*=======================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    public GameObject TapPanel;

    public void ShowTap()
    {
        TapPanel.SetActive(true);
    }
    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    public void EnableInput()
    {
        PlayerInputSystem.instance.enabled = true;
    }

}
