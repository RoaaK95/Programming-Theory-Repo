using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _spawnPosY = 8.0f;
    private float _spawnPosX = 8.0f;
    private float _startDelay = 2.0f;
    private float _spawnInterval = 1.0f;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", _startDelay, _spawnInterval);
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


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
