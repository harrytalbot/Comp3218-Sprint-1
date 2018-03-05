using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public int score = 0;
    public Text scoreText, gameOverText, doubleJumpText, floodSpeedText;

    private bool gameOver;
    private bool restart;

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
        }
        gameOver = false;
        restart = false;
        score = 0;
    }

    private void Update()
    {
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

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateSpeed(float speed)
    {
        floodSpeedText.text = "Flood Speed: " + speed;
    }

}
