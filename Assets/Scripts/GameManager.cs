using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseScreen;
    private bool _isGameOver;
    private bool _isPaused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PausedChanged();
        }
    }
    public void ReloadGame()
    {
        if (_isGameOver == true)
            SceneManager.LoadScene(0);
    }

    public void LoadMenu()
    {
            SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        _isGameOver = true;
    }

    public void Return()
    {
        _isPaused = false;
        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    private void PausedChanged()
    {
        if (!_isPaused && !_isGameOver)
        {
            _isPaused = true;
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;

        }
        else if (_isPaused && !_isGameOver)
        {
            _isPaused = false;
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Exit()
    {
        MainManager.Instance.SaveBestScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
       Application.Quit();
#endif 
    }
}
