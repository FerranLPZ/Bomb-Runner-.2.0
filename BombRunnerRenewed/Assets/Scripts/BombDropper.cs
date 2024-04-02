using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject player;

    public GameObject bombObj;


    public float speed;
    public float distBetween;

    private float distance;



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
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Bombs AWAY!");
            bombDrop();
            //Debug.Log("Bombs AWAY!");

        }

        if (player != null)
        {
            // Cast both positions to Vector2 before calculating the distance
            distance = Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position);

            if (distance < distBetween)
            {
                // Cast player's position to Vector2 and then subtract
                Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;
                direction.Normalize();

                // Check if the player is below the object on the y-axis and prevent moving down if so
                if (player.transform.position.y < transform.position.y)
                {
                    direction.y = 0;
                }

                // Calculate the new position, only moving up or not at all on the y-axis
                Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

                // Move the bomb dropper towards the new position
                // No need to cast newPosition since it's already a Vector2
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }
        }
    }



    void bombDrop()
    {
        bombObj.SetActive(true);
        Instantiate(bombObj, this.transform.position, this.transform.rotation);
    }

    
}
