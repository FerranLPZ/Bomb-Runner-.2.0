using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite newSprite; // Assign this in the inspector with your desired sprite

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component from the GameObject this script is attached to
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //spriteRenderer.sprite = newSprite;
        Debug.Log("In Range");
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = newSprite;
            Debug.Log("Check Point!");
        }
   
    }
}
