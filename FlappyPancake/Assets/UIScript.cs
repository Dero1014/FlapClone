/*========================================================================*/
/*  This script is used as a base and to control UI elements of the game  */
/*========================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public event Action GameStart;

    /*  Singleton start */
    public static UIScript instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    public void StartGame()
    {
        GameStart?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
