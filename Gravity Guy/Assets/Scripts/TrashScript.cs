using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float pushPullSpeed;
    public GameObject grid;

    private void OnTriggerStay2D(Collider2D collision)
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lasers")
        {
            Destroy(gameObject);
            grid.GetComponent<GridScript>().BeatLevel();
        }
    }
}
