using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endMenu;
    private float seconds;
    private int minutes;
    private int hours;

    public GameObject mainCharacter;

    public Text timeDisplay;
    void Start()
    {
        endMenu.SetActive(false);
        seconds = 0;
        minutes = 0;
        hours = 0;
    }


    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }
        if (minutes >= 60)
        {
            minutes = 0;
            hours++;
        }

        timeDisplay.text = hours + " : " + minutes + " : " + (int)seconds;

        if (Input.GetKey(KeyCode.Escape))
        {
            if (endMenu.activeSelf == false)
            {
                winGame();
            }
            else
            {
                Time.timeScale = 1;
                endMenu.SetActive(false);
            }
                
        }

    }

    public void winGame()
    {
        Time.timeScale = 0;
        endMenu.SetActive(true);
    }

    public void exitButtonClick()
    {
        Application.Quit();
    }

    public void playAgainButtonClick()
    {
        Time.timeScale = 1;
        endMenu.SetActive(false);
        seconds = 0;
        minutes = 0;
        hours = 0;
        mainCharacter.GetComponent<CharacterManager>().RespawnEvent();
    }
}
