using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float timeBetweenSpawners = 10;
    public GameObject enemyspawner;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawners);

            GameObject spawner = Instantiate(enemyspawner);
            spawner.GetComponent<EnemySpawnController>().aimplayer = player;
        }
    }
}
