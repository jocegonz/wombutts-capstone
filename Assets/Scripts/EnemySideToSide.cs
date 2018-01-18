﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideToSide : MonoBehaviour {
	public int EnemySpeed;
	public int xMoveDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.7){
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