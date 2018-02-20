using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, yMin, yMax;

}

public class PlayerMover : MonoBehaviour {


    public int playerSpeed = 10;
    public bool lookingLeft = true;
    public int playerJumpPower = 5;
    public float moveX;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround = 9;

	public Boundry boundry;
	private Animator spriteAnimator;

	// Use this for initialization
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
		} else {
			// player is in the air, use air sprites
			spriteAnimator.SetLayerWeight (1, 1);
			spriteAnimator.SetBool ("landing", false);
		}
        MovePlayer();
    }

	// FixedUpdate is called once per physics step
	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().position = new Vector3 (
			Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.x, boundry.xMin, boundry.xMax), 
			Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.y, boundry.yMin, boundry.yMax),
			0.0f
		);
	}

    void MovePlayer()
	{
		// check if jumping
        if (Input.GetButtonDown("Vertical") && grounded)
        {
			grounded = false;
            Jump();
        }

        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && lookingLeft == false)
        {
            TurnAround();
        }
        else if (moveX > 0.0f && lookingLeft == true)
        {
            TurnAround();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed,
            gameObject.GetComponent<Rigidbody2D>().velocity.y);

		spriteAnimator.SetFloat("speed", Mathf.Abs (moveX));
    }

    void Jump()
    {
		spriteAnimator.SetFloat("speed", Mathf.Abs (moveX));
		spriteAnimator.SetTrigger("jump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void TurnAround()
    {
        lookingLeft = !lookingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
