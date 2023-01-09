using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using FD.Dev;

[System.Serializable]
public class Data
{
    public int nowGameStage;
    public int maxGameStage = 1;
}

public class Json : MonoBehaviour
{
    public Data data = new Data(); 
    public static Json Instance;
    private readonly string jsonFileName = "SaveData";

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }

        if (!Directory.Exists(jsonFileName)) { Directory.CreateDirectory(jsonFileName); }

        try
        {
            data = FAED.Load<Data>(Application.dataPath, jsonFileName);
        }
        catch (System.Exception) { }
    }

    public void Save()
    {
        try
        {
            data.Save(Application.dataPath, jsonFileName);
        }
        catch (System.Exception) { }

    }

    public void Read()
    {
        try
        {
            data = FAED.Load<Data>(Application.dataPath, jsonFileName);
        }
        catch { }
    }
}
