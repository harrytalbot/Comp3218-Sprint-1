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
            print(step);
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

            // The final level need the wave to rise after
            floodMoverObject.GetComponent<FloodMover>().shouldRise = shouldRiseAtThisLevel;



        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<PlayerMover>().isGrounded()) {
            print("reached");
            // move wave to just below this layer
            shouldMove = true;
        }
    }

}
