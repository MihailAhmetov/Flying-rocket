using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedLevels", LevelLocker.UnlockedLevelCount);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

}