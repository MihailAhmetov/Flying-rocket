using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private float _nextLevelDelay = 1f;
    [SerializeField] private float _restartLevelDelay = 2.5f;

    private GameSaver _saver;
    private int _currentScene;
   

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _saver = FindObjectOfType<GameSaver>();
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(_nextLevelDelay);

        if(SceneManager.GetActiveScene().buildIndex == LevelLocker.UnlockedLevelCount)
        {
            LevelLocker.UnlockedLevelCount++;
            //_saver.SaveGame();
            PlayerPrefs.SetInt("SavedLevels", LevelLocker.UnlockedLevelCount);
            PlayerPrefs.Save();
            Debug.Log("Game data saved!");
        }

        if (_currentScene + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(_currentScene + 1);
        else 
            SceneManager.LoadScene("Menu");
    }

    public IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(_restartLevelDelay);
        SceneManager.LoadScene(_currentScene);
    }
}
