using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseGameMenu;
    private bool _isPaused;

    //public event UnityAction<bool> PausePressed;

    private void Awake()
    {
        if (FindObjectsOfType<Canvas>().Length > 1)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    private void Resume()
    {
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    private void LoadMenu()
    {
        Time.timeScale = 1;
        _pauseGameMenu.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
