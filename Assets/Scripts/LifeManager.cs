using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    public int lifes;
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
        lifes = 3;
        UiManager.instance.updateLifes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementLife()
    {
        if (lifes < 3)
        {
            lifes++;
            UiManager.instance.updateLifes();
        }

    }
    public void decrementLife()
    {
        if (lifes == 0)
        {
            GameManager.instance.GameOver();
        }
        else
        {
            lifes--;
            UiManager.instance.updateLifes();
        }
    }
}
