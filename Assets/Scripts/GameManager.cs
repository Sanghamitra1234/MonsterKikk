using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool gameOver;

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
        gameOver = false;
        gameStart();
    }
    public void gameStart()
    {
        Debug.Log("GameManager - gamestart()");
        GameObject.Find("MonsterSpawner").GetComponent<MonsterSpawner>().StartSpawingMonsters();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    public void GameOver()
    {
        DifficultyManager.instance.difficulty = 1;
        //stop score not added
        gameOver = true;
        /*      if (AudioManager.instance.sfx == true)
            {
                AudioManager.instance.Play("gameover");
            }
            if (AudioManager.instance.background == true)
            {
                AudioManager.instance.Stop("game");
            }
        */
        GameObject.Find("MonsterSpawner").GetComponent<MonsterSpawner>().StopSpawningMonsters();
        UiManager.instance.GameOver();

    }
}
