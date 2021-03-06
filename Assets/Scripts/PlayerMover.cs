﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, yMin, yMax;

}

public class PlayerMover : MonoBehaviour {

    //GameController
    public GameController gameController;
    // Player Movement Parameters
    public int playerSpeed = 10;
    public bool lookingLeft = true;
    public float moveX;

    // Params about jumping
    public int playerJumpPower = 5;
    private bool doubleJumping;
    public int doubleJumpsRemaining = 0;
    public Rigidbody2D doubleJump;
    public GameObject doubleJumpRespawn;

    // Params to check if on the ground
    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround = 9;

    // Limits of Player Movement
	public Boundry boundry;

    // Animator for the player's sprite  
	private Animator spriteAnimator;
    

	void Start () {
		spriteAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// check if player is on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		// 
		if (grounded) {
			// player is on the ground, use ground sprites
			spriteAnimator.ResetTrigger("jump");
			spriteAnimator.SetLayerWeight (1, 0);
			spriteAnimator.SetBool ("landing", true);
			doubleJumping = false;
		} else {
			// player is in the air, use air sprites
			spriteAnimator.SetLayerWeight (1, 1);
            spriteAnimator.SetTrigger("jump");

            spriteAnimator.SetBool ("landing", false);
		}
        MovePlayer();
    }

	// FixedUpdate is called once per physics step
	void FixedUpdate ()
	{
        // Check the player is not outside the game limits
		GetComponent<Rigidbody2D>().position = new Vector3 (
			Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.x, boundry.xMin, boundry.xMax), 
			Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.y, boundry.yMin, boundry.yMax),
			0.0f
		);
	}

    void MovePlayer()
	{
		// check if jumping
		if (Input.GetButtonDown("Vertical"))
        {
			if (grounded) {
				grounded = false;
				Jump ();
                // correction: no need to check if is enabled, will be enabled if he has jumps
                // so just check if he's not already jumping and has jumps
			}else if (!doubleJumping && doubleJumpsRemaining > 0) {
				doubleJumping = true;
                doubleJumpsRemaining--;
				Jump ();
                // make the controller update the view
                gameController.updateDoubleJump(doubleJumpsRemaining);
                //if the player is in the tutorial and has 10 double jumps left, and is above the powerup level
                if (doubleJumpsRemaining == 10 && transform.position.y > 30 && GameController.isTutorialMode)
                {
                    //Spawn another doubleJump at the location of doubleJumpRespawn
                    Instantiate(doubleJump, doubleJumpRespawn.transform.position, doubleJumpRespawn.transform.rotation);
                }
			}
        }

        // Make sure the sprite is facing the right way
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && lookingLeft == false)
        {
            TurnAround();
        }
        else if (moveX > 0.0f && lookingLeft == true)
        {
            TurnAround();
        }
        
        // Make the player move and update the sprite float 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed,
        gameObject.GetComponent<Rigidbody2D>().velocity.y);
		spriteAnimator.SetFloat("speed", Mathf.Abs (moveX));
    }

    void Jump()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v.y = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
        // Make the player jump and update the sprite float 
        spriteAnimator.SetFloat("speed", Mathf.Abs (moveX));
		spriteAnimator.SetTrigger("jump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    public int pickupJumps()
    {
        doubleJumpsRemaining += 10;
        return doubleJumpsRemaining;
    }

    void TurnAround()
    {
        // Flip the player sprite so they look the right way
        lookingLeft = !lookingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

 
        public bool isGrounded()
    {
        return grounded;
    }
}
