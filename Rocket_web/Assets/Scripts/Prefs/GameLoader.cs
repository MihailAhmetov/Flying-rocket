using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    private void Start()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedLevels"))
        {
            LevelLocker.UnlockedLevelCount = PlayerPrefs.GetInt("SavedLevels");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.Log("There is no save data!");
    }
}
