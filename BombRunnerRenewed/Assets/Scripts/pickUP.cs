using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    public gameMan gameManager;
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //source.Play();
        if (collision.gameObject.tag == "Player")
        {
            source.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //source.Play();
        if (other.CompareTag("Player"))
        {
            
            //source.Play();
            
            gameManager.scorePoint();
            Destroy(gameObject);
        }
    }
}
