using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
			print ("duplicate music player self-destructing");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
