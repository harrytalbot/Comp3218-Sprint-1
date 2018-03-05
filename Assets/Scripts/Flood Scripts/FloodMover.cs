using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodMover : MonoBehaviour {

    public float floodSpeed, delay;
    private float startTime;
    private Vector3 startPos, distMoved;
    private FloodMover floodMover;

    public bool shouldRise;
    // time sent by the clock controller, used to stop movement
    public float waitTime;
    public float elapsedTime;
    void Start()
    {
        waitTime = Time.time;
        transform.position = new Vector3(0, -1, 0);
        floodMover = gameObject.GetComponent<FloodMover>();
        startPos = transform.position;
        elapsedTime = 0;
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
                if (Time.time > waitTime)
                {
                    Vector3 v = transform.position;
                    // Multiply with delta time to give movement smoothly with framerate
                    v.y += (floodSpeed * Time.deltaTime);
                    transform.position = v;
                }
            }
        }
        
    }

}
