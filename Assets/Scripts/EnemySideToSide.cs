using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideToSide : MonoBehaviour {
    public int EnemySpeed;
    public int xMoveDirection;

    private Rigidbody2D body;
    public Rigidbody2D Body {
        get{ 
            this.body = this.body ?? GetComponent<Rigidbody2D>();
            return this.body;
        }
    } 
    //damage script
    private AdventurerAnimation player;

    void Start () {
    	player = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerAnimation>();
    }

    void FixedUpdate() {
		this.Body.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

    void OnCollisionEnter2D (Collision2D collision) {
//        if (collision.gameObject.tag != "Player") {
            Flip();
//        }

		if (collision.gameObject.tag == "Player") {
        	player.Damage(1);
        	StartCoroutine(player.Knockback(0.5f, 350, player.transform.position));
        }
    }

	void OnTriggerEnter2D (Collider2D trigger) {
//        if (trigger.gameObject.tag != "Player") {
            Flip();
//        }

		if (trigger.gameObject.tag == "Player") {
        	player.Damage(1);
        	StartCoroutine(player.Knockback(0.5f, 350, player.transform.position));
        }
    }

    void Flip (){
        if (xMoveDirection > 0) {
            xMoveDirection = -1;
        } else {
            xMoveDirection = 1;
        }
    }


}