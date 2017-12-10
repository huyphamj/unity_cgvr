using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject westGate;
	public GameObject eastGate;
	public GameObject northGate;
	public GameObject southGate;

	public GameObject zombie;
	public GameObject skeleton;
	public GameObject wizard;
	public PlayerController player;

	private float genTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		genTime += Time.deltaTime;
		if (genTime > Config.ZOMBIE_GENERATE_SCHEDULE) {
			generateMonster ();
			genTime = 0;
		}

		if (player.getHp () < 1) {
			endGame ();
		}
	}

	void generateMonster(){
		int rand = Random.Range (1, 5);
		GameObject ob = null;
		switch (rand) {
		case 1:
			ob = westGate;
			break;
		case 2:
			ob = eastGate;
			break;
		case 3:
			ob = northGate;
			break;
		case 4:
			ob = southGate;
			break;
		}
		Vector3 pos = new Vector3();
		foreach (Transform child in ob.transform) {
			if (child.gameObject.name.Equals ("ZombieSpawnPoint"))
				pos = child.transform.position;
		}
		GameObject clone = null;
		rand = Random.Range (1, 4);
		if (rand == 1)
			clone = zombie;
		else if (rand == 2)
			clone = skeleton;
		else if (rand == 3)
			clone = wizard;
		Instantiate (clone, pos, Quaternion.identity);
	}
	
	private void endGame(){
		Debug.Log ("GAME OVER");
	}
}
