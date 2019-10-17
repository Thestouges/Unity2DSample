using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTargetController : MonoBehaviour
{
    public int totalBullets = 1;
    public GameObject bullet;
    public float timeBetweenShot = 1;
    public GameObject target;
    public float bulletspeed = 10;

    float newX;
    float newY;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        newX = target.transform.position.x - transform.position.x;
        newY = target.transform.position.y - transform.position.y;
        StartCoroutine("Spawnbullets");
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= totalBullets)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Spawnbullets()
    {
        while (counter < totalBullets)
        {
            yield return new WaitForSeconds(timeBetweenShot);
            GameObject firedbullet = Instantiate(bullet);
            firedbullet.transform.position = transform.position;

            Vector2 direction = new Vector2(newX, newY);
            firedbullet.transform.up = direction;

            //Debug.Log(firedbullet.transform.up.x + " " + firedbullet.transform.up.y);

            firedbullet.GetComponent<Rigidbody2D>().velocity = firedbullet.transform.up * bulletspeed;

            counter++;
        }
    }
}
