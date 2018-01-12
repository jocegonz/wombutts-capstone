using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerAnimation : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rb;
	public float jumpForce = 700f;
	bool doubleJump = false;

	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Whenever you are using physics, you want to use FixedUpdate, not Update
	void FixedUpdate ()
	{
//		lower force and lower gravity can help you adjust gravity and jumps later
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if (grounded) {
			doubleJump = false;
		}

		anim.SetFloat ("vSpeed", rb.velocity.y);

		float move = Input.GetAxis ("Horizontal");
//		float jumpY = Input.GetAxis("Vertical");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if (!grounded) {
			return;
		}
//		HandleJumpAndFall();

		if (move > 0 &&! facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Update() {
		if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));

			if (!doubleJump && !grounded){
				doubleJump = true;
			}
		}
	}

	void Flip () {
		facingRight =! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void HandleJumpAndFall ()
	{
		if (rb.velocity.y > 0) {
			anim.SetInteger("State", 3);
		} else {
			anim.SetInteger("State", 1);
		}
	}


}
