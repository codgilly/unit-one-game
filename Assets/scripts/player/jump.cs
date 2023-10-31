using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 40f;
    public int extraJumps = 2;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount = 0;
    bool isGrounded;
    float mx;
    float jumpCoolDown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mx = Input.GetAxis("Horizontal");
        if (Input.GetKey("space"))
        {
            Jump();
        }
        CheckGrounded();
        Run();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (mx * speed, rb.velocity.y);
    }

    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
        
    }
    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if(Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Run()
    {
        if (Input.GetKey("left shift") == true)
        {
            speed = speed * 2;
        }

        if (Input.GetKey("a") == true)
        {
            speed = 4f;
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKey("d") == true)
        {
            speed = 4f;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
    }
    

}

