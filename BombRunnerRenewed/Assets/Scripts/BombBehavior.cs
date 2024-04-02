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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("BOOM!");
            explode();
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

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);

    }

}
