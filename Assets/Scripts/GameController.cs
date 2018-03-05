using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public int score;
    public Text scoreText, gameOverText, doubleJumpText, floodSpeedText, timerText;
    public int doubleJumpMax = 15;
    public int doubleJumpAmount = 0;

    private float time;
    private bool gameOver;
    private bool restart;
    public bool runTimer;

    // need these to persist through scene change
    static public bool isTutorialMode;
    static private bool checkPoint = false;

    GameObject playerObject;

    // Use this for initialization
    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        if (checkPoint)
        {
            playerObject.transform.position = new Vector3(-9, 51, 0);
            // player will need to be able to double jump
            playerObject.GetComponent<PlayerMover>().doubleJumpEnabled = true;
            enableDoubleJump();
        }
        gameOver = false;
        restart = false;
        score = 0;
        // timer doesn't exist in tutorial mode
        if (!isTutorialMode)
        {
            time = 0;
            timerText.text = "00:00";
        }
    }

    private void Update()
    {
        if (runTimer)
        {
            updateTimer();
        }

        if (gameOver)
        {
            restart = true;
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Initiate.Fade(SceneManager.GetActiveScene().name, Color.cyan, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                Initiate.Fade("Menu", Color.cyan, 0.5f);
                //clear the checkpoint so if the tutorial is selected again it won't start from level 4
                checkPoint = false;
            }
        }
    }

    public void GameOver()
    {
        gameOver = true;
        if (!isTutorialMode)
        {
            //stop timer
            runTimer = false;
        }

        // only save checkpoint if in tutorial mode, or playing main game will save progress too
        if (playerObject.transform.position.y > 50 && isTutorialMode)
            checkPoint = true;
        gameOverText.text = "GAME OVER\n - Press R to Restart! -\n - Press M for Main Menu - ";
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public bool updateDoubleJump(int change)
    {
        doubleJumpAmount += change;
        if(doubleJumpAmount > 0)
        {
            doubleJumpText.text = "Double Jump Enabled: " + doubleJumpAmount;
            return true;
        }
        else
        {
            doubleJumpText.text = "";
            playerObject.GetComponent<PlayerMover>().doubleJumpEnabled = false;
            return false;
        }
    }

    public void enableDoubleJump()
    {
        updateDoubleJump(doubleJumpMax);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateSpeed(float speed)
    {
        floodSpeedText.text = "Flood Speed: " + speed;
    }
    
    void updateTimer()
    {
        time += Time.deltaTime;
        int mseconds = (int)((time % 1)*100); // calculate the milliseconds
        int seconds = (int) time % 60; // calculate the seconds
        int minutes = (int) time / 60; // calculate the minutes
        timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + mseconds.ToString("D2");
    }
}
