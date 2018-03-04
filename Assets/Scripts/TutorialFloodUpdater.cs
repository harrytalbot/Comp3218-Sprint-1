using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFloodUpdater : MonoBehaviour {

    public float speed;
    public GameObject floodMoverObject;
    public GameObject mainCamera;
    public bool shouldRiseAtThisLevel = false;

    private bool shouldMove, hasMoved;
    private CameraFollower cameraScript;

    // Use this for initialization
    void Start () {

        shouldMove = false;
        hasMoved = false;
        cameraScript = mainCamera.GetComponent<CameraFollower>();

    }

    void Update()
    {
        if (shouldMove && !hasMoved)
        {
            float step = speed * Time.deltaTime;
            floodMoverObject.transform.position = Vector3.MoveTowards(floodMoverObject.transform.position,
                gameObject.transform.position,
                step);
            // move the camera up to the new position;
            if (cameraScript.yMin < gameObject.transform.position.y + 4)
            {
                float difference = gameObject.transform.position.y + 4 - cameraScript.yMin;
                float inc = difference * 3 *  Time.deltaTime;
                cameraScript.yMin += inc;
            }
            if (floodMoverObject.transform.position.y > gameObject.transform.position.y-1)
            {
                hasMoved = true;
                shouldMove = false;
            }

            // Whether the flood should move when it reaches this level
            floodMoverObject.GetComponent<FloodMover>().shouldRise = shouldRiseAtThisLevel;
            // reset the time on the flood so there is some delay
            floodMoverObject.GetComponent<FloodMover>().elapsedTime = 0;


        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<PlayerMover>().isGrounded()) {
            // if the flood hasn't already moved, move wave to just below this layer
            if (!hasMoved)
            {
                // this has to go here as will be done too many times if it's in update
                Vector3 justBelow = new Vector3(floodMoverObject.transform.position.x,
                gameObject.transform.position.y - 10,
                floodMoverObject.transform.position.z);
                floodMoverObject.transform.position = justBelow;
                // then have it rise slowly
                shouldMove = true;
            }
  

        }
    }

}
