using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;
    public Text scoreText;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject GameoverScoreText, NewHighscoreText;
    

    public GameObject life1, life2, life3;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            scoreText.text = ScoreManager.instance.Score.ToString();
        }
    }
    public void GameOver()
    {
        life1.SetActive(false);
        life2.SetActive(false);
        life3.SetActive(false);

        scoreText.gameObject.SetActive(false);
        PauseButton.SetActive(false);
        GameOverPanel.SetActive(true);
        GameoverScoreText.GetComponent<Text>().text = ScoreManager.instance.Score.ToString();
    }
    public void HighScore()
    {
        NewHighscoreText.SetActive(true);
    }


    public void Replay()
    {
        /*   if (AudioManager.instance.sfx == true)
           {
               AudioManager.instance.PlayButton("buttonclick");
           }
        */
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        PauseButton.SetActive(true);
        GameManager.instance.gameOver = false;
        SceneManager.LoadScene("GameScene");
    }
    public void OnApplicationQuit()
    {
        /*   if (AudioManager.instance.sfx == true)
           {
               AudioManager.instance.PlayButton("buttonclick");
           }
       */
        Application.Quit();
    }
    public void MainMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame()
    {
        /*   if (AudioManager.instance.sfx == true)
           {
               AudioManager.instance.PlayButton("buttonclick");
           }
           if (AudioManager.instance.background == true)
           {
               AudioManager.instance.Pause("game");
           }
        */
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        PausePanel.SetActive(true);


    }
    public void PlayPausedGame()
    {
        /*     if (AudioManager.instance.sfx == true)
             {
                 AudioManager.instance.PlayButton("buttonclick");
             }
             if (AudioManager.instance.background == true)
             {
                 AudioManager.instance.ResumeAudio("game");
             }
        */
        PauseButton.SetActive(true);
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void updateLifes()
    {
        int lifes = LifeManager.instance.lifes;
        if (lifes == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lifes == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lifes == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
        else if (lifes == 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
    }
}
