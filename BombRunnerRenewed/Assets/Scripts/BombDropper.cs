using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public Transform player;
    public float yOffset = 0f;
    public float xOffset = 0f;

    void Update()
    {

        if (player != null)
        {

            transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
        }
    }
}
