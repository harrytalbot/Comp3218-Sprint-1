using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            print("Couldn't find controller");
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // check for player touching collider (not other coins)
        if (coll.gameObject.tag == "Player")
        {
     
            Initiate.Fade("Menu", Color.cyan, 0.5f);

        }
    }

}