using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    public poweUp poweUp;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        source.Play();
        Destroy(gameObject);
        poweUp.Apply(collision.gameObject);
    }

}
