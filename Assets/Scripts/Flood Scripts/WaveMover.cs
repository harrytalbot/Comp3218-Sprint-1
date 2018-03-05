using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMover : MonoBehaviour
{
    public float delta = .3f;  // Amount to move left and right from the start point
    public float verticalOffest;
    public float speed = 2.0f;

    void Update()
    {
        Vector3 v = transform.parent.gameObject.transform.position;
        v.x += delta * Mathf.Sin (Time.time * speed);
        v.y += verticalOffest;
        transform.position = v;
    }


}