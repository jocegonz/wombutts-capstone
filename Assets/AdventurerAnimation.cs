using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerAnimation : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rb;

	Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Whenever you are using physics, you want to use FixedUpdate, not Update
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if (move > 0 &&! facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Flip () {
		facingRight =! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
