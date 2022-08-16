using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{   //INHERITANCE
    //POLYMORPHISM
    public override void Movement()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
        if (transform.position.y < _lowerBound)
        {
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_powerupSfx, transform.position, 1);
            if (_player != null)
            {
                _player.SpeedBoostActive();
            }
            Destroy(gameObject);
        }

    }
}