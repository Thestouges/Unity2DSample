using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = player.transform.position.x - transform.position.x;
        float newY = player.transform.position.y - transform.position.y;
        Vector2 direction = new Vector2(newX, newY);

        transform.up = direction;

        //Debug.Log(direction);
    }
}
