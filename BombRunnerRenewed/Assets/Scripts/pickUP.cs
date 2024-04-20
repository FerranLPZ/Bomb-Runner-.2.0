using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    public gameMan gameManager;
    public AudioSource source;
    public bool hasScored = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //source.Play();
        if ((other.CompareTag("Player")) && !hasScored)
        {
            source.Play();
            gameManager.scorePoint();
            hasScored = true;
            Destroy(gameObject);
            
        }
    }
}
