using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public GameObject bullet;
    public float bulletspeed;
    public GameObject bulletspawnpoint;
    public GameObject mine;
    public GameObject spawnshoottarget;
    public GameObject wallbouncebullet;

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
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -10)
        {
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 10)
        {
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -10)
        {
            transform.Translate(-Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 10)
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
        if (Input.GetMouseButtonDown(1) && mousedown == false)
        {
            SpawnMine();
            mousedown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mousedown = false;
        }
        if (Input.GetMouseButtonDown(2) && mousedown == false)
        {
            spawnShootTarget();
            mousedown = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            mousedown = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && mousedown == false)
        {
            spawnWallBouncBullet();
            mousedown = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            mousedown = false;
        }
    }

    private void FireBullet()
    {
        GameObject firedbullet = Instantiate(bullet, bulletspawnpoint.transform.position, this.transform.Find("PlayerSprite").transform.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = this.transform.Find("PlayerSprite").transform.up * bulletspeed;
    }

    public void SpawnMine()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        Vector3 groundedRay = new Vector3(ray.origin.x, ray.origin.y, 0);
        Instantiate(mine, groundedRay, Quaternion.identity);
    }

    public void spawnShootTarget()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        Vector3 groundedRay = new Vector3(ray.origin.x, ray.origin.y, 0);
        GameObject item = Instantiate(spawnshoottarget, groundedRay, Quaternion.identity);
        item.GetComponent<ShootTargetController>().target = this.gameObject;
    }

    public void spawnWallBouncBullet()
    {
        GameObject item = Instantiate(wallbouncebullet, bulletspawnpoint.transform.position, this.transform.Find("PlayerSprite").transform.rotation);
        //item.GetComponent<WallBounceBulletController>().border = GameObject.FindGameObjectWithTag("MainCamera");
    }
}