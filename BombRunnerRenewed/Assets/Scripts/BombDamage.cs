using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //TakeDamage(collision);
        }
    }

    //public void TakeDamage(Collider2D other)
    //{
      //  Player Pl = other.GetComponent<Player>();
    //}
}
