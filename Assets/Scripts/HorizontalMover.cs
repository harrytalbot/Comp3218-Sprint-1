using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    public float delta = .3f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;
	private FloodMover floodMover;
	private float floodSpeed;

    void Start()
    {
		floodMover = transform.parent.gameObject.GetComponent<FloodMover> ();
		floodSpeed = floodMover.floodSpeed;
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
			v.x += delta * Mathf.Sin (Time.time * speed);
        transform.position = v;
    }
}