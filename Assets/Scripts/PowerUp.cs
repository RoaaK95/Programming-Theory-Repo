using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 3f;
    protected float _lowerBound = -6.0f;
    protected PlayerController _player;
    [SerializeField]
    protected AudioClip _powerupSfx;
    // Start is called before the first frame update
    protected void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    protected void Update()
    {
        //ABSTRACTION
        Movement();

    }
    //POLYMORPHISM
    public abstract void Movement();

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_powerupSfx, transform.position, 1);
            if (_player != null)
            {
                //Action On trigger
            }
            Destroy(gameObject);
        }


        /*  private  void  OnTriggerEnter2D(Collider2D other)
          {
              if (other.CompareTag("Player"))
              {
                  AudioSource.PlayClipAtPoint(_powerupSfx, transform.position, 1);
                  if (_player != null)
                  {
                      switch (_powerupID)
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

          }*/
    }
}
