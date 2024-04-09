using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public float impactField;
    public float force;

    public LayerMask hitLayer;

    public AudioSource audioSource;
    public AudioClip boomSound;
    public GameObject hitVFX;


    void Start()
    {
        if (audioSource != null)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    void Update()

        
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("BOOM!");
            explode();
        }
        
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bomb has collided with the player
        if (collision.gameObject.tag == "platform")
        {
            //Debug.Log("Bomb HIT");
            Invoke("explode", 1f);
            //explode();

        }
        else if (collision.gameObject.tag == "Player")
        {
            explode();
        }
    }


    void explode()
    {
        audioSource.PlayOneShot(boomSound);

        if (hitVFX != null)
        {
            Instantiate(hitVFX, transform.position, Quaternion.identity);
        }

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, hitLayer);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = (obj.transform.position - transform.position).normalized; // Get the normalized direction.
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                
                rb.AddForce(direction * force);

                // If the object has a Player script attached to it, deal damage
                PlayerControll playerScript = obj.GetComponent<PlayerControll>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(2); // Replace someDamageAmount with the actual amount of damage
                }
            }
        }

        gameObject.SetActive(false); // Or Destroy(gameObject); to remove the bomb after exploding
    }



}
