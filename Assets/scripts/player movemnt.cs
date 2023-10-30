using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovemnt : MonoBehaviour
{
 
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoRunL();
        DoRunR();

        void DoJump()
        {
            if (Input.GetKey("space")==true)
            {
                rb.AddForce(new Vector3(0, 1, 0), (ForceMode2D)ForceMode2D.Impulse);
            }
        }
        void DoRunR()
        {
            float speed = 7f;
            if (Input.GetKey("left shift") == true)
            {
                speed = speed * 2;
            }

            if (Input.GetKey("d") == true)
            {
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }

        }
        void DoRunL()
        {
            float speed = 7f;
            if (Input.GetKey("left shift") == true)
            {
                speed = speed * 2;
            }

            if (Input.GetKey("a") == true)
            {
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            }

        }
    }
}
