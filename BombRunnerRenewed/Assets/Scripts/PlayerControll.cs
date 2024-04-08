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
    public int maxhealth = 100;
    public int currentHealth;
    private bool isDead;


    private bool isMoving = false;
    public gameMan gameManager;


    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxhealth;

        animator = GetComponent<Animator>();
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

        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
        }

        if (xInput > 0)
        {
            // Moving right - ensure the sprite is not flipped
            transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else if (xInput < 0)
        {
            // Moving left - flip the sprite by making its x-scale negative
            transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", false);
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    
}
