using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public float MineActivationTime = 2;
    public GameObject bullet;
    public float MinebulletSpeed = 10;
    public float totalBulletsSpawn = 8;
    float spawntime;
    // Start is called before the first frame update
    void Start()
    {
        spawntime = Time.unscaledTime;
        //Debug.Log("mine x:" + transform.position.x + " y:" + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime - spawntime >= MineActivationTime)
        {
            SpawnMinebullets();
            Destroy(this.gameObject);
        }
    }

    private void SpawnMinebullets()
    {
        for (int i = 1; i <= totalBulletsSpawn; i++)
        {
            float angle = 2 * Mathf.PI / totalBulletsSpawn * i;
            Vector3 point = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);

            GameObject firedbullet = Instantiate(bullet);
            firedbullet.transform.position = transform.position + point * 1;

            //firedbullet.transform.position = this.gameObject.transform.position;



            //firedbullet.transform.Rotate(this.gameObject.transform.position, angle);
            //firedbullet.transform.position += Quaternion.AngleAxis(angle, this.gameObject.transform.position).eulerAngles;

            //firedbullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //firedbullet.GetComponent<Rigidbody2D>().velocity = firedbullet.transform.up * MinebulletSpeed;

            float newX = transform.position.x - firedbullet.transform.position.x;
            float newY = transform.position.y - firedbullet.transform.position.y;
            Vector2 direction = new Vector2(newX, newY);

            firedbullet.transform.up = direction;

            firedbullet.GetComponent<Rigidbody2D>().velocity = firedbullet.transform.up * MinebulletSpeed;
            //Debug.Log(angle);
        }
    }
}
