using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private float _lowerBound = -6.0f;
    private PlayerController _player;
    [SerializeField]
    private int _powerupID;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
        if (transform.position.y < _lowerBound)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(_player!=null)
            {
                switch(_powerupID)
                {
                    case 0:
                         _player.TripleShotActive();
                        break;
                    case 1:
                        _player.SpeedBoostActive();
                        break;
                   case 2:
                        _player.ShieldActive();
                        break;
                    default:
                        //default value
                        break;
                }    
               
            }
            Destroy(gameObject);
        }
    }
}
