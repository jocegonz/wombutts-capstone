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
    void FixedUpdate() {
		this.Body.velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

    void OnCollisionEnter2D (Collision2D collision) {
        Debug.Log("collision");
        if (collision.gameObject.tag != "Player") {
            Flip();

        }
    }


    void Flip ()
    {
        if (xMoveDirection > 0) {
            xMoveDirection = -1;
        } else {
            xMoveDirection = 1;
        }
    }


}