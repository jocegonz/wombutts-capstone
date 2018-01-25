﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideToSide : MonoBehaviour {
    public int EnemySpeed;
    public int xMoveDirection;
    bool facingRight = true;

    private Rigidbody2D body;
    public Rigidbody2D Body {
        get{ 
            this.body = this.body ?? GetComponent<Rigidbody2D>();
            return this.body;
        }
    } 

    private AudioSource hurtAudio;
    //damage script
    private AdventurerAnimation player;

    void Start () {
		hurtAudio = GetComponent<AudioSource>();
    	player = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerAnimation>();
    }

    void FixedUpdate() {
		this.Body.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag != "Player") {
            Flip();
        }


		if (collision.gameObject.tag == "Player") {
			if (!player.isInvincible) {
				player.isInvincible = true;
	        	player.Damage(1);
//	        	StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
	        	hurtAudio.Play();
	        	Invoke("notInvincible", 0.5f);

			}
        }
    }

    void notInvincible() {
    	player.isInvincible = false;
    }

	void OnTriggerEnter2D (Collider2D trigger) {
//        if (trigger.gameObject.tag != "Player") {
            Flip();
//        }

		if (trigger.gameObject.tag == "Player") {
			if (!player.isInvincible) {
				player.isInvincible = true;
	        	player.Damage(1);
//	        	StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
	        	Invoke("notInvincible", 0.5f);

			}
        }
    }

    void Flip (){
		facingRight =! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

        if (xMoveDirection > 0) {
            xMoveDirection = -1;
        } else {
            xMoveDirection = 1;
        }
    }


}

