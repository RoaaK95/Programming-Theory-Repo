using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    private float _speedBoost = 2;
    private float _xBound = 11.3f;
    private float _upperBound = -3.8f;
    private float _lowerBound = 0f;
    private Vector3 _startPostion = new Vector3(0, -3.14f, 0);
    private Vector3 _offset = new Vector3(0, 1.05f, 0);
    private Vector3 _tripleShotoffset = new Vector3(-1.01f, -0.4f, 0);
    private float _fireRate = 0.5f;
    private float _canFire = -1.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private bool _isTripleShotActive;
    [SerializeField] private GameObject _tripleShotPrefab;
    private bool _isSpeedBoostActive;
    private bool _isShieldActive;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject _rightEngineVisualizer, _leftEngineVisualizer;
    public int _score, _bestScore;
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _laserShotSfx;
    [SerializeField]
    private GameObject _explosionPrefab;
    private AudioSource _playerAudioSource;
    // Start is called before the first frame update
    void Start()
    {
       
        transform.position = _startPostion;
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _playerAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);




        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _upperBound, _lowerBound), 0);

        if (transform.position.x >= _xBound)
        {
            transform.position = new Vector3(-_xBound, transform.position.y, 0);
        }

        else if (transform.position.x <= -_xBound)
        {
            transform.position = new Vector3(_xBound, transform.position.y, 0);
        }


    }
    void FireLaser()
    {
        _canFire = _fireRate + Time.time;
        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position + _tripleShotoffset, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + _offset, Quaternion.identity);
        }

        _playerAudioSource.PlayOneShot(_laserShotSfx, 0.6f);

    }

    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }
        _lives--;
        _uiManager.UpdateLives(_lives);

        if (_lives == 2)
        {
            _rightEngineVisualizer.SetActive(true);

        }
        else if (_lives == 1)
        {
            _leftEngineVisualizer.SetActive(true);
        }
        else if (_lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }




    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }


    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }


    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedBoost;
        StartCoroutine(SpeedBoostPowerDownRoutine());

    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedBoost;
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        _shieldVisualizer.SetActive(true);
    }

    public void SetScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void CheckForBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            _uiManager._bestScoreText.text = "Best: " + _bestScore;

        }

    }
}
