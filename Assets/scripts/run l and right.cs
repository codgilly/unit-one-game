using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovemnt : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask groundlayer;


    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float speed = 2.4f;
            if (Input.GetKey("left shift") == true)
            {
                speed = speed * 2;
            }

            if (Input.GetKey("a") == true)
            {
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            }
            if (Input.GetKey("d") == true)
            {
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }     
       
           
        


    }
}

