﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	private Animator anim;
	private PlayerController player;

	private int hp = Config.SKELETON_HP;
	private float attackTime = Config.SKELETON_ATTACK_TIME;
	private float delayAfterAttack = Config.SKELETON_DELAY_AFTER_ATTACK;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool(Constant.ZOMBIE_ANIM_WALKING, true);
		player = FindObjectOfType<PlayerController>();
	}

	// Update is called once per frame
	void Update(){
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 5);
	}
	//void Update () {
	//	transform.Translate (a);
		/*
		if(anim.GetBool(Constant.ZOMBIE_ANIM_DEAD))
			return;
		attackTime -= Time.deltaTime;
		delayAfterAttack -= Time.deltaTime;
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);

		float degree = MyUtils.calculateZombieRotate (player.transform.position.x, player.transform.position.z, transform.position.x, transform.position.z);
		transform.eulerAngles = new Vector3(0, degree + 180, 0);

		float distance = MyUtils.calculateDistance (this.transform.position, player.transform.position);
		if (distance < Config.SKELETON_ATTACK_RANGE)
			attack ();
		else
			chasePlayer ();*/
	//}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Bullet")) {
			Bullet bullet = other.gameObject.GetComponent<Bullet>();
			hp -= bullet.getDamage();
			if (hp < 1) {
				anim.SetBool(Constant.ZOMBIE_ANIM_DEAD, true);
				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<Collider>());
				this.Invoke("DestroyZombie", Config.MONSTER_DESTROY_TIME);
			}
			Destroy(other.gameObject);
		}
	}

	void chasePlayer(){
		//swordCollider.enabled = false;
		anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, true);
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);
		if (delayAfterAttack < 0) {
			transform.Translate (new Vector3 (0, 0, -Config.SKELETON_MOVE_SPEED));
		}
	}

	void attack(){
		if (attackTime < 0) {
			anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, false);
			anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, true);
			attackTime = Config.SKELETON_ATTACK_TIME;
			delayAfterAttack = Config.SKELETON_DELAY_AFTER_ATTACK;
		}
	}

	void OnCollisionEnter(Collision other){
	}

	void DestroyZombie(){
		Destroy(this.gameObject);
	}
}
