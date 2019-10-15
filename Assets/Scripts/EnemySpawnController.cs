using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public int spawnPerXSecond = 10;
    public GameObject enemy;
    public GameObject aimplayer;
    public float distanceFromPlayer=20;

    bool start;
    // Start is called before the first frame update
    

    void Start()
    {
        //StartCoroutine("Spawner");
        Time.timeScale = 1;
        start = false;
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            StartCoroutine("Spawner");
            start = true;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPerXSecond);

            GameObject item = Instantiate(enemy);
            var comp = item.GetComponent<FacePlayerController>();
            comp.player = aimplayer;

            float angle = Random.Range(0.0f, Mathf.PI * 2);
            Vector3 point = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle),0);

            item.transform.position = aimplayer.transform.position+point * distanceFromPlayer;
            //item.transform.position = aimplayer.transform.position + (item.transform.position - aimplayer.transform.position).normalized * distanceFromPlayer;
            //item.transform.RotateAround(aimplayer.transform.position, Vector3.up, Random.Range(0,359));

            //Debug.Log(item.transform.position);
        }
    }
}
