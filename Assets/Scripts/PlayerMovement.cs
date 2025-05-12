using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public bool isFacingRight;

    private float timeBtwnAttack;
    public float startTimeBtwnAttack;

    [SerializeField] private GameObject attackSprite;
    [SerializeField] private GameObject attackPose;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private KeyCode attackKey;
    [SerializeField] private string jumpButton;
    [SerializeField] private string axis;


    [SerializeField] private GameObject healthBar;

    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.GetComponent<HealthBar>().SetValue(health);

        horizontal = Input.GetAxisRaw(axis);
        // Debug.Log(horizontal);

        Flip();

        if (Input.GetButtonDown(jumpButton) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // jump higher by pressing jump and jump lower etc
        if (Input.GetButtonUp(jumpButton) && (rb.linearVelocity.y > 0f))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (Input.GetKey(attackKey))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            attackSprite.GetComponent<SpriteRenderer>().enabled = true;
            attackSprite.GetComponent<PlayerAttack>().Attack();

        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            attackSprite.GetComponent<SpriteRenderer>().enabled = false;
        }


        // extra: cooldown for attacks
        // if (timeBtwnAttack <= 0)
        // {
        //     // Attack!
        //     if (Input.GetKey(attackKey))
        //     {
        //         attackPose.GetComponent<PlayerAttack>().Attack();
        //     }
        //     timeBtwnAttack = startTimeBtwnAttack;
        // }
        // else
        // {
        //     timeBtwnAttack -= Time.deltaTime;
        // }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        // invisible circle at players feet and when it collides w ground layer we are allowed to jump.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void TakeDamage(int damage)
    {
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN!");
    }
}
