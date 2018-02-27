using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodMover : MonoBehaviour {

	public float floodSpeed, delay;
    private float startTime, elapsedTime;
    private Vector3 startPos, distMoved;
    private FloodMover floodMover;
    public bool shouldRise;

    void Start()
    {
        floodMover = gameObject.GetComponent<FloodMover>();
        startPos = new Vector3(5.5f, -5.0f, 0.0f);
       
        transform.position = startPos;
        //startPos = transform.position;
        print("start pos " + startPos);
        delay = 2; elapsedTime = 0;
    }

    void Update()
    {
        // first, wait for the delay so the wave movement is not instant
        elapsedTime += Time.deltaTime;
        // once enough time has passed...
        if (elapsedTime > delay) {
            // and the wave should rise 
            if (shouldRise)
            {
                Vector3 v = transform.position;
                // Multiply with delta time to give movement smoothly with framerate
                v.y += (floodSpeed * Time.deltaTime);
                transform.position = v;
            }
        }
        
    }

}
