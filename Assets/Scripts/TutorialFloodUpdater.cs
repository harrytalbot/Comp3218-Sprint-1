using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFloodUpdater : MonoBehaviour {

    public float speed;
    public GameObject floodMoverObject;

    private bool shouldMove, hasMoved;

    // Use this for initialization
    void Start () {

        shouldMove = false;
        hasMoved = false;

    }

    void Update()
    {
        if (shouldMove && !hasMoved)
        {
            float step = speed * Time.deltaTime;
            floodMoverObject.transform.position = Vector3.MoveTowards(floodMoverObject.transform.position,
                gameObject.transform.position,
                speed);
            if (floodMoverObject.transform.position.y > gameObject.transform.position.y-1)
            {
                hasMoved = true;
                shouldMove = false;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            print("reached");
            // move wave to just below this layer
            shouldMove = true;
            
        }
    }

}
