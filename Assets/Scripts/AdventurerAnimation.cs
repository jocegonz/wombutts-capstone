using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//figure out aircontrol
public class AdventurerAnimation : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rb;

//	bool doubleJump = false;

	Animator anim;

//	bool grounded = false;

	[SerializeField]
	public Transform[] groundCheck;
	public float groundRadius;
//	private float groundRadius = 2f;
	public LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	private float jumpForce = 700f;
	public bool airControl;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Whenever you are using physics, you want to use FixedUpdate, not Update
	void FixedUpdate ()
	{	
		
//		lower force and lower gravity can help you adjust gravity and jumps later
//		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
//		anim.SetBool ("Ground", grounded);

//		if (grounded) {
//			doubleJump = false;
//		}

//		anim.SetFloat ("vSpeed", rb.velocity.y);
		if (rb.velocity.y < 0){
			anim.SetBool("landing", true);
		}

//		x-axis
		float move = Input.GetAxis ("Horizontal");

		isGrounded = IsGrounded();
//		Start running
		anim.SetFloat ("Speed", Mathf.Abs (move));
		if (isGrounded || airControl){
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		}


//		if (isGrounded || airControl) {
//			return;
//		}

		if (move > 0 &&! facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}


		HandleLayers();
		ResetValues();

	}

	void Update ()
	{	
		if (Input.GetKeyDown(KeyCode.Space)){
			jump = true;
		}

		if (isGrounded && jump){
			isGrounded = false;
			rb.AddForce(new Vector2(0, jumpForce));
			anim.SetTrigger("jump");
		}
//		if (grounded) {
//			anim.SetBool("Ground", false);
//		}
//		if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)){
//			anim.SetBool("Ground", false);
//			rb.AddForce(new Vector2(0, jumpForce));
//
//			if (!doubleJump && !grounded){
//				doubleJump = true;
//			}
//		}
	}

	void Flip () {
		facingRight =! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

//	void HandleJumpAndFall ()
//	{
//		if (rb.velocity.y > 0) {
//			anim.SetInteger("State", 3);
//		} else {
//			anim.SetInteger("State", 1);
//		}
//	}

	private void HandleLayers ()
	{
		if (!isGrounded) {
			anim.SetLayerWeight(1, 1);
		} else {
			anim.SetLayerWeight(1, 0);
		}
	}

	private bool IsGrounded ()
	{
//		are you falling or on the ground?
		if (rb.velocity.y <= 0) {
			foreach (Transform point in groundCheck) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders[i].gameObject != gameObject) {
						anim.ResetTrigger("jump");
						anim.SetBool("landing", false);
						return true;
					}
				}
			}
		}
		return false;
	}

	private void ResetValues() {
		jump = false;
	}
}
