using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public float speed = 1f; 
	public PlayerController player;

	private Vector3 startPos;
	private int range = 13;
	private int dmg = 1;

	// Use this for initialization
	void Start () {
		this.name = "Pistol";
		player = FindObjectOfType<PlayerController>();
		Quaternion q = player.transform.localRotation;
		this.transform.localRotation = q;
		this.transform.Rotate(new Vector3(90, 0, 0));
		startPos = new Vector3(transform.position.x, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, speed, 0));
		Vector3 curPos = this.transform.position;
		if (Mathf.Abs(curPos.x - startPos.x) > range)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
	}

	public int getDamage()
	{
		return dmg;
	}
}
