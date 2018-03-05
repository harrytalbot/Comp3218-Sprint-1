using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodSpeedIncrease : MonoBehaviour {


    public FloodMover floodMover;
    public float increase;

    private GameController gameController;
    private bool hasIncreasedSpeed = false;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        // check for player touching collider 
        if (coll.gameObject.tag == "Player" && !hasIncreasedSpeed)
        {
            // increase flood speed
            floodMover.floodSpeed = floodMover.floodSpeed + increase;
            gameController.UpdateSpeed(floodMover.floodSpeed);
            hasIncreasedSpeed = true;
        }
    }
}
