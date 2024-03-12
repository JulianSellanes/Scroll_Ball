using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public bool canRun;
    public bool running;
    public bool onGround;
    public bool dobleJump;

    public float checkRadio = 0.07f;
    public Transform groundChecker;
    public LayerMask groundMask;

    public Rigidbody2D rb;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(dobleJump)
            GetComponent<SpriteRenderer>().color = Color.red;
        else
            GetComponent<SpriteRenderer>().color = Color.green;

        if (Input.GetMouseButtonDown(0))
        {
            if(running)
            {
                /*if(onGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    rb.AddForce(new Vector2(0, jumpForce));

                    onGround = false;
                }
                else
                {
                    if(!dobleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        rb.AddForce(new Vector2(0, jumpForce));

                        dobleJump = true;
                    }
                }*/

                
                if(onGround || !dobleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    rb.AddForce(new Vector2(0, jumpForce));

                    if (!onGround && !dobleJump)
                    {
                        dobleJump = true;
                    }

                    onGround = false;
                }
            }
            else
            {
                if(canRun)
                {
                    running = true;

                    foreach (Spawner item in GameController.instance.spawnersScri)
                    {
                        item.Generate();
                    }
                    //GameController.instance.Generate();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if(running)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        //onGround = Physics2D.OverlapCircle(groundChecker.position, checkRadio, groundMask);

        if(onGround)
        {
            dobleJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")// && !canRun)
        {
            if (!canRun)
            {
                speed = 7f;
                canRun = true;
            }

            onGround = Physics2D.OverlapCircle(groundChecker.position, checkRadio, groundMask);
        }
    }
}