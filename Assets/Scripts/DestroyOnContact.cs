using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameController gameController;
	public PlayerMover playerMover;

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

        GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) 
		{
			playerMover = playerObject.GetComponent<PlayerMover> ();
        }
        else
        {
            print("Couldn't find player");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // check for player touching collider (not other coins)
        if (coll.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                gameController.AddScore(1);
                Destroy(gameObject);
            }
            if (gameObject.tag == "DoubleJump")
            {
                int jumps = coll.gameObject.GetComponent<PlayerMover>().pickupJumps();
                gameController.updateDoubleJump(jumps);
                Destroy(gameObject);
            }

            if (gameObject.tag == "Water")
            {
                // remove player
                Destroy(coll.gameObject);
                gameController.GameOver();
            }

        }
        // Destrpy anything the water touches as we don't need it any more...

        if (coll.gameObject.tag == "Water") {
			Destroy (gameObject);
		}


        


    }


}
