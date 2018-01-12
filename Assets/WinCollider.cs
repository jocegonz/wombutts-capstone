using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour {

	private LevelManager levelManager;
//	IEnumerator OnTriggerEnter2D(Collider2D trigger) {
//		yield return new WaitForSeconds(5f);
//		levelManager = FindObjectOfType<LevelManager>(); 
//		levelManager.LoadLevel("Win");
//	}

	IEnumerator OnCollisionEnter2D(Collision2D collision) {
		print("Collision");		
		yield return new WaitForSeconds(1f);
		levelManager = FindObjectOfType<LevelManager>(); 
		levelManager.LoadLevel("Win");
	}
}
