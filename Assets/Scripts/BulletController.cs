using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletDespawnInSeconds;
    float spawntime;
    void Start()
    {
        spawntime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.up;
        if(Time.unscaledTime - spawntime >= BulletDespawnInSeconds)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("killed enemy");
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
