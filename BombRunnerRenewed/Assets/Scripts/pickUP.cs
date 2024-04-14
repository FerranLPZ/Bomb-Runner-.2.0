using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    public gameMan gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.scorePoint();
            
        }
    }
}
