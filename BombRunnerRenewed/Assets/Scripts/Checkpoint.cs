using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite newSprite; // Assign this in the inspector with your desired sprite
    public bool isChecked = false;
    public PlayerControll player;

    private SpriteRenderer spriteRenderer;
    private AudioSource source;

    void Start()
    {
        // Get the SpriteRenderer component from the GameObject this script is attached to
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the bomb has collided with the player
        if (other.CompareTag("Player"))
        {
            source.Play();
            Debug.Log("Check Point!");
            spriteRenderer.sprite = newSprite;
            isChecked = true;
            player.setNewSpawn(transform.position);
        }
        
    }
}
