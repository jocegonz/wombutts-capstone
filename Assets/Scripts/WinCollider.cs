using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour {

	private LevelManager levelManager;
//	private AdventurerAnimation player;
//	IEnumerator OnTriggerEnter2D(Collider2D trigger) {
//		yield return new WaitForSeconds(5f);
//		levelManager = FindObjectOfType<LevelManager>(); 
//		levelManager.LoadLevel("Win");
//	}

//	void Start () {
//		player = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerAnimation>();
//	}
	IEnumerator OnCollisionEnter2D(Collision2D collision) {
			
//		player.GetComponent<Animator>().Play("winning");
		gameObject.GetComponent<Animation>().Play("HeartItemWon");

		yield return new WaitForSeconds(5f);
		levelManager = FindObjectOfType<LevelManager>(); 
		levelManager.LoadLevel("Win");
	}
}
