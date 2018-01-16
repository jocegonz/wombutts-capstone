using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {
	private BoxCollider2D playerCollider;
	public BoxCollider2D platformCollider;
	public BoxCollider2D platformTrigger;
	// Use this for initialization
	void Start () {
		playerCollider = GameObject.Find("Adventurer").GetComponent<BoxCollider2D>();
		Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Adventurer") {
			Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
		}	
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "Adventurer") {
			Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
		}
	}
}
