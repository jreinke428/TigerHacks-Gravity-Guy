using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    Vector2 movement;
    public float moveSpeed;
    public float jumpSpeed;
    bool jumping = false;


    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Flip();
        checkGrounded();
    }

    void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f);
        rb.position += movement;
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && !jumping)
        {
            jumping = true;
            rb.velocity = new Vector2(0f,jumpSpeed);
        }
    }

    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.flipX = true;
        }else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
    }

    void checkGrounded()
    {
        if (rb.velocity.y == 0)
        {
            jumping = false;
        }
    }
}
