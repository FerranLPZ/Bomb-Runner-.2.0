using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 3f;
    public Vector2 movement;
    public float jumpStrenght;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public bool grounded;
    public float drag = 0.95f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = Vector2.up * jumpStrenght;
        }

    }

    void FixedUpdate()
    {
        CheckGround();
        if (grounded)
        {
            Vector2 horizontalVelocity = rb.velocity;
            horizontalVelocity.x *= drag;
            rb.velocity = horizontalVelocity;
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapBox(groundCheck.bounds.center, groundCheck.bounds.size, 0f, groundMask) != null;
    }
}
