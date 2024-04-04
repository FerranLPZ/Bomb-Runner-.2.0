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

    //The AudioSource component to play the sounds; assign this in the Inspector.

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
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, hitLayer);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        //boomSound.Play();
        audioSource.PlayOneShot(boomSound);
        //gameObject.GetComponent<AudioSource>().Play();


        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);

    }

    

}
