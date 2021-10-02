using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string SaveName = "SaveFile";
    void Start()
    {
        SaveData.current = (SaveData)Serialzation.Load(Application.persistentDataPath + "/saves/" + SaveName + "/.sv");
    }

    private void OnDisable()
    {
        Serialzation.Save("SaveFile", SaveData.current);
        print("Restart");
    }
}
