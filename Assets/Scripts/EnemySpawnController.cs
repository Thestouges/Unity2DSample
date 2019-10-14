using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public int spawnPerXSecond = 10;
    public GameObject enemy;
    public GameObject aimplayer;
    // Start is called before the first frame update
    

    void Start()
    {
        StartCoroutine("Spawner");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPerXSecond);

            GameObject item = Instantiate(enemy);
            var comp = item.GetComponent<FacePlayerController>();
            comp.player = aimplayer;

            item.transform.position = aimplayer.transform.position + (item.transform.position - aimplayer.transform.position).normalized * 20;
            item.transform.RotateAround(aimplayer.transform.position, Vector3.up, Random.Range(0,359));
        }
    }
}
