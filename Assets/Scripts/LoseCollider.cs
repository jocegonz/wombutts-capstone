using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	IEnumerator OnTriggerEnter2D(Collider2D trigger) {
		yield return new WaitForSeconds(.5f);
		levelManager = FindObjectOfType<LevelManager>(); 
		levelManager.LoadLevel("Lose");
	}

	IEnumerator OnCollisionEnter2D(Collision2D collision) {
		print("Collision");		
		yield return new WaitForSeconds(.5f);
		levelManager = FindObjectOfType<LevelManager>(); 
		levelManager.LoadLevel("Lose");
	}
}