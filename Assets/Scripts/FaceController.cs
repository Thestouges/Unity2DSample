using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        float newX = mousepos.x - transform.position.x;
        float newY = mousepos.y - transform.position.y;
        Vector2 direction = new Vector2(newX, newY);

        transform.up = direction;
    }
}
