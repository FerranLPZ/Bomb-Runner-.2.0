using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public float impactField;
    public float force;

    public LayerMask hitLayer;


    void Update()

        
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("BOOM!");
            explode();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bomb has collided with the player
        if (collision.gameObject.tag == "platform")
        {
            Debug.Log("Bomb HIT");
            Invoke("explode", 2f);
            //explode();


        }
    }


    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, hitLayer);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

       
        gameObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);

    }

}
