﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotate : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // spin around
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
