using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public PlayerMover playerMover;
    public FloodMover floodMover;

    public float waitTime = 2;

    private bool beenUsed = false;



    // Use this for initialization
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerMover = playerObject.GetComponent<PlayerMover>();
        }


    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        // check for player touching collider 
        if (coll.gameObject.tag == "Player")
        {
            if (!beenUsed)
            {
                // tell the flood it can't move for 2 seconds
                floodMover.waitTime = Time.time + waitTime;
                beenUsed = true;

                GetComponent<Animator>().speed = 0;

            }

        }
    }
}
