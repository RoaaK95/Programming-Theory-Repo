using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool _isGameOver;


    private void Update()
    {
        if (_isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void GameOver()
    {
        _isGameOver = true;
    }
}
