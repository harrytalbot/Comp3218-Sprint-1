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
        startPos = transform.position;
        delay = 2; elapsedTime = 0;
    }

    void Update()
    {
        // first, wait for the delay so the wave movement is not instant
        elapsedTime += Time.deltaTime;
        print("" + elapsedTime);
        // once enough time has passed...
        if (elapsedTime > delay) {
            // and the wave should rise 
            //BUG: jumps if the variable is changed to true after the delay has passed. Goes back to origin on change to false.
            if (shouldRise)
            {
                // Move all the waves by moving the parent's transform
                Vector3 v = this.transform.position;
                // elapsedTime - delay prevents jumping due to time passed
                
                v.y += ((elapsedTime - delay) * floodSpeed);
                distMoved = v;
                this.transform.position = v;

            }
            else           
            {
            }
        }
        
    }

}
