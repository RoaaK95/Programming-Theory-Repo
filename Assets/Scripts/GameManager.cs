using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool _isGameOver;


   public void ReloadGame()
    {
        if (_isGameOver == true)
            SceneManager.LoadScene(0);
    }

    public void LoadMenu()
    {
        if (_isGameOver == true)
            SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        _isGameOver = true;
    }
}
