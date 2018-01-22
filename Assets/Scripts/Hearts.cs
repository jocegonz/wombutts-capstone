using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hearts : MonoBehaviour {

	private LevelManager levelManager;

	public Sprite[] heartSprites;
	public Image heartUI;
	private AdventurerAnimation player;


    void Start () {
    	levelManager = FindObjectOfType<LevelManager>();
    	player = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerAnimation>();
    }

    void Update ()
	{
		if (player.currentHealth < 0) {
			levelManager.LoadLevel ("Lose");
		} else {
			heartUI.sprite = heartSprites[player.currentHealth];
		}
    	
    }
}