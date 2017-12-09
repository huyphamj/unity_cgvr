using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour {

	private Animator anim;
	private int hp = 3;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("isWalking", true);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Bullet"))
		{
			Bullet bullet = other.gameObject.GetComponent<Bullet>();
			hp -= bullet.getDamage();
			if (hp < 1)
			{
				Debug.Log("abc");
				//anim.SetBool("isWalking", false);
				anim.SetBool("isDead", true);
				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<Collider>());
				this.Invoke("DestroyZombie",2.0f);
			}
			Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("onCollisionEnterZombie");
	}

	void DestroyZombie()
	{
		Destroy(this.gameObject);
	}
}
