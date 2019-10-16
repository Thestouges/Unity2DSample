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
        for (int i = 0; i < totalBulletsSpawn; i++)
        {
            GameObject firedbullet = Instantiate(bullet);
            firedbullet.transform.position = this.gameObject.transform.position;

            float angle = 359 / totalBulletsSpawn * i;
            firedbullet.transform.Rotate(this.gameObject.transform.position, angle);

            //firedbullet.transform.rotation = Quaternion.AngleAxis(360 / totalBulletsSpawn * i, Vector3.up);
            firedbullet.GetComponent<Rigidbody2D>().velocity = firedbullet.transform.up * MinebulletSpeed;
        }
    }
}
