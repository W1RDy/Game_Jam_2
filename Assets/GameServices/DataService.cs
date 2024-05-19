using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataService : IService
{
    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("Level", 1);
        }
    }

    public void SaveData(int levelIndex)
    {
        PlayerPrefs.SetInt("Level", levelIndex);
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
}
