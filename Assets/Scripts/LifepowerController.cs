using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifepowerController : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 5;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Movelife();

    }

    void Movelife()
    {
        if (!GameManager.instance.gameOver)
        {
            rb.velocity = new Vector2(0, -speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "belowwall" && !GameManager.instance.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
