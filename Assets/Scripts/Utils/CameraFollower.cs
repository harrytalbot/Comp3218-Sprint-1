﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    [SerializeField]
    public float xMin, xMax, yMin, yMax;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax),
                Mathf.Clamp(player.position.y, yMin, yMax),
                transform.position.z);
        }
	}
}
