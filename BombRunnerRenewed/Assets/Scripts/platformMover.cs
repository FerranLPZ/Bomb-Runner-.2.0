using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMover : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 2.0f;
    private bool movingToEnd = true; // Track the current direction of the platform

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (movingToEnd)
        {
            MoveToPosition(endPos);
        }
        else
        {
            MoveToPosition(startPos);
        }
    }

    void MoveToPosition(Vector3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the platform has reached the target position
        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd; // Toggle the movement direction
        }
    }


}
