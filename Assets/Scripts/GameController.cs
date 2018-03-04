using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public int score = 0;
    public Text scoreText, gameOverText, doubleJumpText;

    private bool gameOver;
    private bool restart;

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
        }
    }

    public void GameOver()
    {
        gameOver = true;
        if (playerObject.transform.position.y > 50)
            checkPoint = true;
        gameOverText.text = "GAME OVER\n - Press R to Restart! - ";
    }

    public void goToMainMenu()
    {
        gameOver = true;
        SceneManager.LoadScene(SceneManager.GetSceneByName("Menu").buildIndex);
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

}
