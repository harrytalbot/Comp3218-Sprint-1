using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOT WORKING
public class HorizontalMover : MonoBehaviour
{
    public float speed = 2.0f;
    public float dist = 0;
    private float elapsedTime = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;


        if (elapsedTime > dist) {
            print(elapsedTime);
            rb.AddForce(Vector2.left * speed);
            speed *= -1;
            elapsedTime = 0;
        }

    }
}