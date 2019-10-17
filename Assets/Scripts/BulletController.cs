using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletDespawnInSeconds;
    public int bounces = 0;
    float spawntime;
    void Start()
    {
        spawntime = Time.unscaledTime;

        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log("x " + stageDimensions.x + " y " + stageDimensions.y);
        Debug.Log("size:" + Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.up;
        if (Time.unscaledTime - spawntime >= BulletDespawnInSeconds && bounces >= 0)
        {
            Destroy(this.gameObject);
        }
        if (bounces > 0)
        {
            /*
            Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            if (transform.position.x < stageDimensions.x)
            {
                
                Vector2 direction = new Vector2(-transform.rotation.x, transform.rotation.y);
                transform.up = direction;
                bounces--;
            }
            */
        }
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (transform.position.x > stageDimensions.x)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > stageDimensions.y)
        {
            Destroy(this.gameObject);
        }
        
        if (transform.position.x < stageDimensions.x - Camera.main.orthographicSize*4)
        {
            Destroy(this.gameObject);
        }
        
        
        if (transform.position.y < stageDimensions.y - Camera.main.orthographicSize*2)
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
