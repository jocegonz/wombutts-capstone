using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour {

	private LevelManager levelManager;
	private AudioSource winAudio;

	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); 
		winAudio = GetComponent<AudioSource>();
	}

	IEnumerator OnCollisionEnter2D(Collision2D collision) {		
		winAudio.Play();	
		gameObject.GetComponent<Animation>().Play("HeartItemWon");
		yield return new WaitForSeconds(5f);
	
		levelManager.LoadLevel("Win");
	}
}
