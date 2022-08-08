using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    private float _xBound = 11.3f;
    private float _upperBound = -3.8f;
    private float _lowerBound = 0f;
    private Vector3 _startPostion = new Vector3(0, -3.14f, 0);
    private Vector3 _offset = new Vector3(0, 1.05f, 0);
    private float _fireRate = 0.5f;
    private float _canFire = -1.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private TextMeshProUGUI _livesText;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _startPostion;
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
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
        Instantiate(_laserPrefab, transform.position + _offset, Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;
        _livesText.text = "lives: " + _lives;
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
