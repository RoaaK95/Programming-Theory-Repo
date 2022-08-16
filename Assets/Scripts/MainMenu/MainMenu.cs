using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
   
    public void LoadGame()
    {
        if(MainManager.Instance!=null)
        {
          MainManager.Instance.LoadBestScore();
        }
        SceneManager.LoadScene(0);
        
        
    }

    public void InstructionsButton()
    {
        SceneManager.LoadScene(2);
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
