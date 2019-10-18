using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceBulletController : MonoBehaviour
{
    public int totalbullet = 1;
    public int totalbounce = 1;
    public GameObject bullet;
    public float bulletspeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("wall bullet");
        GameObject firedbullet = Instantiate(bullet, transform.position, transform.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed;
        firedbullet.GetComponent<BulletController>().bounces = totalbounce;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
