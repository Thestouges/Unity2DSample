using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 6.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enemy killed player");
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
