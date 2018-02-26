using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D r2d;
    private bool steppedOn = false;
    private float timer = 0f;
    public float delay = 1.0f;


    void start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerMover playerMover = coll.gameObject.GetComponent<PlayerMover>();
            if (playerMover.isGrounded())
            {
                print("collision");
                steppedOn = true;
            }
        }
    }


    IEnumerator fall()
    {
        yield return new WaitForSeconds(delay);
        r2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (steppedOn)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                // disable collider so it falls through floor
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                GetComponent<Rigidbody2D>().gravityScale = 5;
                // Disabling collider means that it won't be stopped by water, so manuall destroy it
                Object.Destroy(gameObject, 3.0f);
            }
        }
	}
}
