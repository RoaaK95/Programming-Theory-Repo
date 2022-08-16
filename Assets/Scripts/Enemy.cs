using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private float _lowerBound = -6.0f;
    private PlayerController _player;
    private Animator _enemyAnimator;
    private AudioSource _enemyAudioSource;
    private Collider2D _enemyCollider;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _enemyAnimator = GetComponent<Animator>();
        _enemyAudioSource = GetComponent<AudioSource>();
        _enemyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < _lowerBound)
        {

            Destroy(gameObject);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (_player != null)
            {
                //ABSTRACTION
                _player.Damage();


            }
            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _enemyAudioSource.Play();
            Destroy(gameObject, 2.8f);
        }

        if (other.CompareTag("Laser"))
        {

            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.SetScore(10);
            }

            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _enemyAudioSource.Play();
            Destroy(_enemyCollider);
            Destroy(gameObject, 2.8f);
        }
    }


}
