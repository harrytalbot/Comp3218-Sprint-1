using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script soley to change the speed of an animation
public class AnimationSpeedAdjuster : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.speed = speed;
    }
	
}
