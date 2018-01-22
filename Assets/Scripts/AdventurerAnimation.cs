using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerAnimation : MonoBehaviour {

	private LevelManager levelManager;

	//ANIMATION
	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rb;

	Animator anim;

	[SerializeField]
	public Transform[] groundCheck;
	public float groundRadius;
	public LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	private float jumpForce = 700f;
	public bool airControl;
	//END ANIMATION

	//HEALTH
	public int currentHealth;
	public int maxHealth = 5;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		levelManager = FindObjectOfType<LevelManager>(); 
		currentHealth = maxHealth;

	}
	
	// Whenever you are using physics, you want to use FixedUpdate, not Update
	void FixedUpdate ()
	{	

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
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0) {
			zeroHearts();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.tag == "Win") {
			print("Collision is happening with win item");	
			anim.SetBool("won", true);
		}
//		if (collision.gameObject.tag == "Enemy") {
//			anim.SetBool("hurt", true);
//		}
	}

	void Flip () {
		facingRight =! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void zeroHearts(){
		levelManager.LoadLevel("Lose");
	}

	public void Damage(int dmg) {
		currentHealth -= dmg;
//		anim.SetBool("hurt", true);
//		gameObject.GetComponent<Animation>().Play("hurt");

//		gameObject.GetComponent<Animation>().wrapMode = WrapMode.Once;
		gameObject.GetComponent<Animation>().Play("hurt");
		print("Animation for hurt played");
	}

	public IEnumerator Knockback (float knockDuration, float knockPower, Vector3 knockDirection) {
		float timer = 0;

		while (knockDuration > timer) {
			timer += Time.deltaTime;

			rb.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
		}

		yield return 0;
	}

	private void HandleLayers () {
		if (!isGrounded) {
			anim.SetLayerWeight(1, 1);
		} else {
			anim.SetLayerWeight(1, 0);
		}
	}

	private bool IsGrounded () {
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
