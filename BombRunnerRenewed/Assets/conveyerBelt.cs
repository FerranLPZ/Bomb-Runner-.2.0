using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyerBelt : MonoBehaviour
{
    Animator m_Animator;
    public bool isReversed = false;
    
    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        SetAnimationSpeeds();

       
    }

    // Update is called once per frame
    void Update()
    {

        SetAnimationSpeeds();

    }


    void SetAnimationSpeeds()
    {
        foreach (Transform segment in transform)
        {
            Animator animator = segment.GetComponent<Animator>();
            if (animator != null)
            {
                if (speed > 0)
                {
                    animator.speed = speed;
                }

                //animator.speed = speed;
                if (isReversed)
                {
                    animator.SetFloat("direction", -1);
                }
            
            
            }
            else
            {
                Debug.Log("No Animator found on segment: " + segment.gameObject.name);
            }
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            collision.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else
        {
            Debug.Log("No Rigidbody2D found on object: " + collision.gameObject.name);
        }
    }
}
