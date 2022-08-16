using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class MainManager : MonoBehaviour
{
    //ENCAPSULATION
    public static MainManager Instance { get; private set;}
    public int _bestScore;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }
    [Serializable]
    class SaveData
    {
        public int _bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data._bestScore = _bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _bestScore = data._bestScore;
        }
    }
}
