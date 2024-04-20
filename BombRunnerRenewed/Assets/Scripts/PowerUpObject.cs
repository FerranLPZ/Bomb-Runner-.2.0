using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    public poweUp poweUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        poweUp.Apply(collision.gameObject);
    }

}
