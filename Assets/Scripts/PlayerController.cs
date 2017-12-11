using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject bullet;
	public GameObject bulletPosition;

	private int hp = 10;
	private Animator anim;
	private float atkCooldown = Config.PLAYER_ATTACK_SPEED;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		/*int degree = 0;
		isMoving = false;
*/
		atkCooldown -= Time.deltaTime;

		Vector3 mouseLocation = Input.mousePosition;
		anim.SetBool("isMoving", false);
		transform.eulerAngles = new Vector3(0, MyUtils.calculatePlayerRotate(mouseLocation.x, mouseLocation.y, Screen.width, Screen.height), 0);

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			anim.SetBool("isMoving", true);
			GetComponent<Rigidbody> ().velocity = new Vector3 (10, 0, 10);
			/*Vector3 a;
			if(Input.GetKey(KeyCode.W))
				a = new Vector3(transform.position.x, transform.position.y, transform.position.z + Config.PLAYER_MOVE_SPEED);
			else
				a = new Vector3(transform.position.x, transform.position.y, transform.position.z - Config.PLAYER_MOVE_SPEED);
			transform.position= a;*/
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			anim.SetBool("isMoving", true);
			Vector3 a;
			if(Input.GetKey(KeyCode.D))
				a = new Vector3(transform.position.x + Config.PLAYER_MOVE_SPEED, transform.position.y, transform.position.z);
			else
				a = new Vector3(transform.position.x - Config.PLAYER_MOVE_SPEED, transform.position.y, transform.position.z);
			transform.position= a;
		}

		if (Input.GetMouseButton(0) && atkCooldown < 0)
		{
			attack ();
		}
	}

	private void attack(){
		atkCooldown = Config.PLAYER_ATTACK_SPEED;
		Instantiate (bullet, bulletPosition.transform.position, Quaternion.identity);
	}

	void OnTriggerEnter(Collider other){
		int damageTaken = MyUtils.getMonsterDamageByTag (other.gameObject.tag);
		hp -= damageTaken;
	}

	public int getHp(){
		return this.hp;
	}
}
