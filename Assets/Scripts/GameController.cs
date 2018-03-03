using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public int score = 0;
    public Text scoreText;

    private int saved = 0;

    private bool gameOver;
    private bool restart;

    // Use this for initialization
    private void Start()
    {
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

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }

    public void GameOver()
    {
        gameOver = true;
        scoreText.text = scoreText.text + " - Press R to Restart!";
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
