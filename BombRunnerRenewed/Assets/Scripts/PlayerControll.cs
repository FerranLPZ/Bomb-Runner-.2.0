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
    private bool isDead = false;
    public SpriteRenderer spriteRenderer;


    private bool isMoving = false;
    public gameMan gameManager;
    public HealthBar healthBar;

    public Vector3 startPoint;

    
    public static Vector3 spawnPoint = new Vector3(0, -4, 0);
    



    //public Vector3 startSpawn;

    private Animator animator;
    private AudioSource source;

    public GameObject checkpoint1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxhealth;

        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        //transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * movespeed, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump") && grounded && !isDead)
        {
            rb.velocity = Vector2.up * jumpStrenght;
            animator.SetBool("isMoving", false);
            source.Play();
        }

        if(currentHealth <= 0 && !isDead)
        {

            Debug.Log("YOU ARE DEAD!");
            gameManager.gameOver();
            isDead = true;  
            animator.SetBool("isMoving", false);
        }

        if (xInput > 0 && !isDead)
        {
            // Moving right - ensure the sprite is not flipped
            transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else if (xInput < 0 && !isDead)
        {
            // Moving left - flip the sprite by making its x-scale negative
            transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else if (!isDead)
        {
            isMoving = false;
            animator.SetBool("isMoving", false);
        }

        else
        {
            // Rotate the player by 90 degrees around the z-axis upon death
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            spriteRenderer.color = Color.red;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the bomb has collided with the player
        if (other.CompareTag("laser"))
        {
            TakeDamage(15);
        }

        if (other.CompareTag("spikes"))
        {
            TakeDamage(10);
        }

    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapBox(groundCheck.bounds.center, groundCheck.bounds.size, 0f, groundMask) != null;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (spriteRenderer != null)
        {
            StopCoroutine("FlashRed");  // Ensure any ongoing flash is stopped before starting a new one
            StartCoroutine(FlashRed());  // Start the flash effect
        }
    }

    public void setNewSpawn(Vector3 newSpawn)
    {
        spawnPoint = newSpawn;
    }

    public Vector3 getSpawn()
    {
        return spawnPoint;
    }

    public void ApplyJumpBuff(float amount, float duration)
    {
        jumpStrenght += amount;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.yellow;
        }
        StartCoroutine(RemoveJumpBuffAfterDelay(amount, duration));
    }

    private IEnumerator RemoveJumpBuffAfterDelay(float amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        jumpStrenght -= amount;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void ApplySpeedBuff(float amount, float duration)
    {
        movespeed += amount;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.cyan;
        }
        StartCoroutine(RemoveSpeedBuffAfterDelay(amount, duration));
    }

    private IEnumerator RemoveSpeedBuffAfterDelay(float amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        movespeed -= amount;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }


    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;  // Change color to red
        yield return new WaitForSeconds(1.0f);  // Wait for 1 or 2 seconds
        spriteRenderer.color = Color.white;  // Change color back to white
    }

    public void ApplyHealthBuff(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxhealth);
        healthBar.SetHealth(currentHealth);
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.cyan;
        }
    }

    }
