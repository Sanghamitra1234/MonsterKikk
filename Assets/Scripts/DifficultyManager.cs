using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public int difficulty;
    public static DifficultyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        difficulty = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int score = (int)ScoreManager.instance.Score;
        if (score > 100)
        {
            difficulty = 5;
        }
        else if (score > 50)
        {
            difficulty = 4;
        }
        else if (score > 20)
        {
            difficulty = 3;
        }
        else if (score > 10)
        {
            difficulty = 2;
        }
    }
}
