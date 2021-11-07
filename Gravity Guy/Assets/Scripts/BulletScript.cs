using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    GameObject player;
    GameObject grid;

    private void Start()
    {
        player = GameObject.Find("Player");
        grid = GameObject.Find("Grid");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().shooting = false;
            grid.GetComponent<GridScript>().PlaceBlock(gameObject.transform.position);
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "Trash" && grid.GetComponent<GridScript>().curInput=="gravity")
        {
            player.GetComponent<PlayerMovement>().shooting = false;
            grid.GetComponent<GridScript>().ChangeTrashGravity();
            Destroy(gameObject);
        }
    }
}
