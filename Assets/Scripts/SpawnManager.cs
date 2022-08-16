using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerupPrefabs; 
    private float _spawnPosY = 8.0f;
    private float _spawnPosX = 8.0f;
    private float _startEnemyDelay = 3.0f;
    private float _spawnEnemyInterval = 1.0f;
    private float _startPowerupDelay = 6.0f;
    private float _spawnPowerupInterval = 20.0f;
    private bool _stopSpawning = false;


   public void StartSpawning()
    {
        //ABSTRACTION
        InvokeRepeating("SpawnEnemies", _startEnemyDelay, _spawnEnemyInterval);
        InvokeRepeating("SpawnPowerup", _startPowerupDelay, _spawnPowerupInterval);
    }

    void SpawnEnemies()
    {
        if(_stopSpawning==false)
        {
            float randomX = Random.Range(-_spawnPosX, _spawnPosX);
            Vector3 spawnPos = new Vector3(randomX, _spawnPosY, 0);
            Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        }

    }

    void SpawnPowerup()
    {
        if(_stopSpawning==false)
        {
            float randomX = Random.Range(-_spawnPosX, _spawnPosX);
            Vector3 spawnPos = new Vector3(randomX, _spawnPosY, 0);
            int powerupIndex = Random.Range(0, _powerupPrefabs.Length);
            Instantiate(_powerupPrefabs[powerupIndex], spawnPos, Quaternion.identity);
        }
    }
    


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
