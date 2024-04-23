using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform player; 
    public float yOffset = 0f;
    public float xOffset = 0f; 
   

    void Update()
    {
        if (player != null)
        {
            // Update camera's position to follow the player's x and y positions with respective offsets
            transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
        }
    }
}

