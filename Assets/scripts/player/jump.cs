using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float speed = 16f;
    public float jumpPower = 50f;
    public int extraJumps = 2;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        anim.SetBool("run", false);
        anim.SetBool("jump", false);

        if (Input.GetKey("space"))
        {
            Jump();
        }
        CheckGrounded();
        Run();
        DoAttack();

    }
    private void FixedUpdate()
    {
        //.velocity = new Vector2 (mx * speed, rb.velocity.y);
    }

    void DoAttack()
    {
        if (Input.GetKeyDown("f"))
        {
            anim.SetTrigger("attack");
        }
    }
    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
            anim.SetBool("jump", true);
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
            anim.SetBool("jump", true);
        }
        else
        {
            isGrounded = false;
        }
    }

    void Run()
    {


        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool(("run"), true);
            sr.flipX = true;

        }
        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool(("run"), true);
            sr.flipX = false;

        }
    }



}

