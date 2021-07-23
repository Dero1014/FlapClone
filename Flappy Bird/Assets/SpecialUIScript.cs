using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialUIScript : UIScript
{

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    public void ShowTap()
    {
        TapPanel.SetActive(true);
    }

}
