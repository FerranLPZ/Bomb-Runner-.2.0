using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject player;

    public GameObject bombObj;


    public float speed;
    public float distBetween;
    public float desiredHeightAbovePlayer;

    public float range;

    private float distance;
    private bool isDroppingBomb = false;



    void Start()
    {

        if (Input.GetKeyDown(KeyCode.G) && bombObj.activeInHierarchy == false)
        {
            Debug.Log("Bombs AWAY!");
            bombDrop();
            //Debug.Log("Bombs AWAY!");

        }

    }

    void Update()
    {
        

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= range && !isDroppingBomb)
        {
            isDroppingBomb = true;
            Debug.Log("Bombs AWAY!");
            InvokeRepeating("bombDrop", 0f, 5f);
        }
        else if (distanceToPlayer > range && isDroppingBomb)
        {
            isDroppingBomb = false;
            CancelInvoke("bombDrop");
        }


        if (player != null)
        {
            // Calculate horizontal distance between the BombDropper and the player
            float horizontalDistance = Mathf.Abs(transform.position.x - player.transform.position.x);

            // Calculate the target position for the BombDropper directly above the player at the desired height
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + desiredHeightAbovePlayer, transform.position.z);

            // If the BombDropper is within the horizontal distance threshold, only adjust Y position
            if (horizontalDistance < distBetween)
            {
                // Smoothly move the BombDropper towards the target position at the specified speed
                // This will adjust both X (if needed) and Y positions dynamically
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                // If outside the horizontal distance threshold, adjust X and Y positions towards the player
                // Smoothly move towards a point directly above the player, respecting the desiredHeightAbovePlayer
                Vector3 horizontalTargetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, horizontalTargetPosition, speed * Time.deltaTime);

                // Separately adjust the vertical position to ensure it smoothly follows the player's Y position
                // This maintains the BombDropper directly above or at a fixed height above the player
                float newYPosition = Mathf.MoveTowards(transform.position.y, targetPosition.y, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }
        }
    }



    void bombDrop()
    {
        // Check if the bomb is already active, and if so, don't instantiate another
        if (bombObj.activeInHierarchy)
        {
            Debug.Log("Bomb already active, waiting to drop the next one.");
            return;
        }

        Debug.Log("Dropping bomb.");
        bombObj.SetActive(true);
        Instantiate(bombObj, this.transform.position, this.transform.rotation);
    }
}