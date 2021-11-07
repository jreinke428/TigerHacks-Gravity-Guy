using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;

    private void Update()
    {
        FollowMouse();
        Flip();
    }

    void FollowMouse()
    {
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Flip()
    {

        if(gun.transform.eulerAngles.z > 90 && gun.transform.eulerAngles.z < 270)
        {
            gun.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
