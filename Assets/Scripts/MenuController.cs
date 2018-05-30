using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject settingPanel, soundON, soundOFF, sfxON, sfxOFF, helpPanel;
    public GameObject help, achievements,leaderboards, settings, gamename,playButton;
    public int sound = 0, sfx = 0;
    bool settingState = false;
    // Use this for initialization
    void Start()
    {


        //Audio Settings Part
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 0);
        }
        else
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        if (!PlayerPrefs.HasKey("sfx"))
        {
            PlayerPrefs.SetInt("sfx", 0);
        }
        else
        {
            sfx = PlayerPrefs.GetInt("sfx");
        }
        UpdateSettingsPanel();


        //start backgound music
        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Play("menu");
        }
          
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Settings()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
        
        if (!settingState)
        {
            settingPanel.SetActive(true);
            settingState = true;
        }
        else
        {
            settingPanel.SetActive(false);
            settingState = false;
        }
    }
    void UpdateSettingsPanel()
    {
        if (sound == 0)
        {
            soundON.SetActive(true);
            soundOFF.SetActive(false);
        }
        else
        {
            soundON.SetActive(false);
            soundOFF.SetActive(true);
        }
        if (sfx == 0)
        {
            sfxON.SetActive(true);
            sfxOFF.SetActive(false);
        }
        else
        {
            sfxON.SetActive(false);
            sfxOFF.SetActive(true);
        }
    }
    public void soundOn()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
    
    
    //In sound On button click we will off the sound
        sound = 1;
        PlayerPrefs.SetInt("sound", 1);
        AudioManager.instance.background = false;
        UpdateSettingsPanel();

        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Play("menu");
        }
        else
        {
            AudioManager.instance.Stop("menu");
        }
   

    }
    public void soundOff()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
         
        sound = 0;
        PlayerPrefs.SetInt("sound", 0);
        AudioManager.instance.background = true;
        UpdateSettingsPanel();
        
        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Play("menu");
        }
        else
        {
            AudioManager.instance.Stop("menu");
        }
        
    }
    public void sfxOn()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
        

        sfx = 1;
        PlayerPrefs.SetInt("sfx", 1);
        AudioManager.instance.sfx = false;
        UpdateSettingsPanel();
    }
    public void sfxOff()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
        sfx = 0;
        PlayerPrefs.SetInt("sfx", 0);
        AudioManager.instance.sfx = true;
        UpdateSettingsPanel();
    }
    public void Leaderboards()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
    }
    public void Achievements()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
   
    }
    public void Help()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
        
        helpPanel.SetActive(true);
        help.SetActive(false);
        gamename.SetActive(false);
        settings.SetActive(false);
        achievements.SetActive(false);
        leaderboards.SetActive(false);
        playButton.SetActive(false);      
    }
    public void HelpTick()
    {
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.PlayButton("buttonclick");
        }
        
        helpPanel.SetActive(false);
        help.SetActive(true);
        gamename.SetActive(true);
        settings.SetActive(true);
        achievements.SetActive(true);
        leaderboards.SetActive(true);
        playButton.SetActive(true);
    }
}
