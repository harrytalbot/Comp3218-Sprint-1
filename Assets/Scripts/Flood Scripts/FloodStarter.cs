using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloodStarter : MonoBehaviour
{

    public FloodMover floodMover;
    private GameController gameController;

    private void Start()
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

        // check for player touching collider 
        if (coll.gameObject.tag == "Player")
        {   
            gameController.UpdateSpeed(floodMover.floodSpeed);
            floodMover.shouldRise = true;
            gameController.runTimer = true;

        }
    }
}