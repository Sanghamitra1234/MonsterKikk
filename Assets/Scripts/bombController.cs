using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour {


    Rigidbody2D rb;
    float speed = 2;
    int difficulty = 1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setSpeed();
        MoveBomb();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void MoveBomb()
    {
        if (!GameManager.instance.gameOver)
        {
            rb.velocity = new Vector2(0, -speed);
        }
    }

    void setSpeed()
    {
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty == 1)
        {
            speed = Random.Range(2, 3);
        }
        else if (difficulty <= 3)
        {
            speed = Random.Range(3, 4);
        }
        else
        {
            speed = 3 + Random.Range(1, 4);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "belowwall" && !GameManager.instance.gameOver)
        {
            Destroy(gameObject);
        }
    }
    public void setZeroSpeed()
    {
        speed = 0;
    }
}
