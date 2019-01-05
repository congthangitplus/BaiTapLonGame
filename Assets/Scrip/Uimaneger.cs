using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimaneger : MonoBehaviour {


    public Button[] buttons;
    bool gameOver;

    // Use this for initialization
    void Start() {
        Time.timeScale = 1;
        //gameOver = false;
        //score = 0;
        //InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        //ScoreText.text = "Score:" + score;

    }


    public void Play()
    {
        Application.LoadLevel("level1");
    }

    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void gameOverActivated()
    {
        //gameOver = true;
        Time.timeScale = 0;
    }

    public void menubutton()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }


    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Menu()
    {
        Application.LoadLevel("MenuScences");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void HeightScore()
    {

    }
}
