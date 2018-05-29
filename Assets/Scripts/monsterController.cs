using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 2, xSpeed;
    int difficulty = 1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setSpeed();
        MoveMonster();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void MoveMonster()
    {
        if (!GameManager.instance.gameOver)
        {
            rb.velocity = new Vector2(xSpeed, -speed);
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "belowwall")
        {
            LifeManager.instance.decrementLife();
        }
        else if (col.gameObject.tag == "wall")
        {
            xSpeed = -xSpeed;
            MoveMonster();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "belowwall" && !GameManager.instance.gameOver)
        {
            Destroy(gameObject);
             LifeManager.instance.decrementLife();
        }
        else if (col.gameObject.tag == "wall")
        {
            xSpeed = -xSpeed;
            MoveMonster();
        }
    }
    void setSpeed()
    {
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty == 1)
        {
            speed = 2 + Random.Range(1, 3);
            xSpeed = 0;
        }
        else if (difficulty == 2)
        {
            int x = Random.Range(0, 5);
            if (x > 3)
            {
                xSpeed = Random.Range(-3, 3);
            }
            speed = 3 + Random.Range(0, 3);
        }
        else if (difficulty == 3)
        {
            int x = Random.Range(0, 5);
            if (x > 3)
            {
                xSpeed = Random.Range(-5, 5);
            }
            speed = 4 + Random.Range(0, 3);
        }
        else
        {
            int x = Random.Range(0, 5);
            if (x > 3)
            {
                xSpeed = Random.Range(-8, 8);
            }

            speed = 5 + Random.Range(0, 3);
        }
    }
}
