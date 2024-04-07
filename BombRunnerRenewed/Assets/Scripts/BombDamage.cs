using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
           
            PlayerControll player = collision.GetComponent<PlayerControll>();

            
            if (player != null)
            {
                player.TakeDamage(damageAmount);

                
                HealthBar healthBar = FindObjectOfType<HealthBar>(); 
                if (healthBar != null)
                {
                    healthBar.SetHealth(player.currentHealth);
                }
            }
        }
    }
}
