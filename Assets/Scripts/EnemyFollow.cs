using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public float enemySpeed;
	Animator enemyAnimator;
	public GameObject enemy;
	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 5f;
	float nextFlipChance = 0f;

	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D rb;

//	void Start() {
//		rb = GetComponent<Rigidbody2D>();
//	}
//
//	void Update ()
//	{
//		if (Time.time > nextFlipChance) {
//			if (Random.Range(0, 10) >= 5) {
//				Facing();
//			}
//			nextFlipChance = Time.time + flipTime;
//		}
//	}
//
//	void OnTriggerEnter2D (Collider2D other) {
//		if () {
//
//		}
//	}
//
//	void Facing () {
//		if (!canFlip) {
//			return;
//		}
//		float facingX = enemy.transform.localScale.x;
//		facingX *= -1f;
//		enemy.transform.localScale.x = new Vector3(facingX, enemy.transform.localScale.y, enemy.transform.localScale.z);
//		facingRight = !facingRight;
//	}

//	public float fpsPlayerDistance;
//	public float enemyLookDistance;
//	public float attackDistance;
//	public float enemyMovementSpeed;
//	public float damping;
//	public Transform fpsPlayer;
//	Rigidbody2D rb;
//	Renderer myRender;
//
//	// Use this for initializationb
//	void Start () {
//		myRender =GetComponent<Renderer>();
//		rb = GetComponent<Rigidbody2D>();
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate () {
//		fpsPlayerDistance = Vector3.Distance(fpsPlayer.position, transform.position);
//		if (fpsPlayerDistance < enemyLookDistance) {
//			myRender.material.color = Color.red;
//			LookAtPlayer();
//			print("Wombat is looking at player");
//		}
//		if (fpsPlayerDistance < attackDistance) {
//			AttackPlayer();
//			print ("Attack player");
//		}
//	}
//
//	void LookAtPlayer() {
//		Quaternion rotation = Quaternion.LookRotation(fpsPlayer.position - transform.position);
//		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
//	}
//
//	void AttackPlayer() {
//		rb.AddForce(transform.forward * enemyMovementSpeed);
//	}
}
