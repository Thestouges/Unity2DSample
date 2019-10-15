using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public GameObject bullet;
    public float bulletspeed;

    float horizontal;
    float vertical;
    

    bool mousedown;

    // Start is called before the first frame update
    void Start()
    {
        mousedown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetMouseButtonDown(0) && mousedown == false)
        {
            FireBullet();
            mousedown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mousedown = false;
        }
    }

    private void FireBullet()
    {
        GameObject firedbullet = Instantiate(bullet, this.transform.position, this.transform.Find("PlayerSprite").transform.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = this.transform.Find("PlayerSprite").transform.up * bulletspeed;
    }
}