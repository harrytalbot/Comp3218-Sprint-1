using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    // public GameObject asteriodExplosion, playerExplosion;
    public GameController gameController;
	public PlayerMover playerMover;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
           gameController = gameControllerObject.GetComponent<GameController>();
        }

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) 
		{
			playerMover = playerObject.GetComponent<PlayerMover> ();
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // check for player touching collider (not other coins)
        if (coll.gameObject.tag == "Player" && gameObject.tag == "Coin")
        {
            gameController.AddScore(1);
            Destroy(gameObject);
        }

		if (coll.gameObject.tag == "Player" && gameObject.tag == "DoubleJump")
		{
			Destroy(gameObject);
			playerMover.doubleJump = true;
		}

		if (coll.gameObject.tag == "Water" && gameObject.tag == "Coin") {
			Destroy (gameObject);
		}

        if (coll.gameObject.tag == "Player" && gameObject.tag == "Water")
        {
            // remove player
            Destroy(coll.gameObject);
        }


    }

 
}
