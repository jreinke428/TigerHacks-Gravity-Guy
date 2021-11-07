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
    public float pushPullSpeed;
    public float bulletForce;
    bool jumping = false;
    public bool shooting = false;
    public GameObject bullet;
    public GameObject gun;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Flip();
        checkGrounded();
        Shoot();
        AnimatorChecks();
    }

    void AnimatorChecks()
    {
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("Direction", Input.GetAxisRaw("Horizontal"));
        animator.SetBool("Flipped", sprite.flipX);
        animator.SetFloat("ySpeed", rb.velocity.y);
    }

    void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f);
        rb.position += movement;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !jumping)
        {
            jumping = true;
            rb.velocity = new Vector2(0f, jumpSpeed);
        }
    }

    void checkGrounded()
    {
        if (rb.velocity.y == 0)
        {
            jumping = false;
        }
    }

    void Flip()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < rb.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && !shooting)
        {
            var b = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(b.transform.right * bulletForce, ForceMode2D.Impulse);
            shooting = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "PushUp")
        {
            rb.velocity = new Vector2(rb.velocity.x, pushPullSpeed);
        }
        else if (collision.gameObject.tag == "PushRight")
        {
            rb.velocity = new Vector2(pushPullSpeed, rb.velocity.y);
        }
        else if (collision.gameObject.tag == "PushDown")
        {
            rb.velocity = new Vector2(rb.velocity.x, -pushPullSpeed);
        }
        else if (collision.gameObject.tag == "PushLeft")
        {
            rb.velocity = new Vector2(-pushPullSpeed, rb.velocity.y);
        }
        else if (collision.gameObject.tag == "PullUp")
        {
            rb.velocity = new Vector2(rb.velocity.x, -pushPullSpeed);
        }
        else if (collision.gameObject.tag == "PullRight")
        {
            rb.velocity = new Vector2(-pushPullSpeed, rb.velocity.y);
        }
        else if (collision.gameObject.tag == "PullDown")
        {
            rb.velocity = new Vector2(rb.velocity.x, pushPullSpeed);
        }
        else if (collision.gameObject.tag == "PullLeft")
        {
            rb.velocity = new Vector2(pushPullSpeed, rb.velocity.y);
        }

    }
}