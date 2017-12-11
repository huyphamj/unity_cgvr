using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {
	public Summon summon;
	public GameObject summonPos1;
	public GameObject summonPos2;
	public GameObject summonPos3;

	private Animator anim;
	private PlayerController player;

	private int hp = Config.WIZARD_HP;
	private float attackTime = 0;
	private float delayAfterAttack = Config.WIZARD_DELAY_AFTER_ATTACK;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool(Constant.ZOMBIE_ANIM_WALKING, true);
		player = FindObjectOfType<PlayerController>();
	}

	// Update is called once per frame
	//void Update(){
	//}
	void Update () {
		if(anim.GetBool(Constant.ZOMBIE_ANIM_DEAD))
			return;
		attackTime -= Time.deltaTime;
		delayAfterAttack -= Time.deltaTime;
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);

		float degree = MyUtils.calculateZombieRotate (player.transform.position.x, player.transform.position.z, transform.position.x, transform.position.z);
		transform.eulerAngles = new Vector3(0, degree, 0);

		float distance = MyUtils.calculateDistance (this.transform.position, player.transform.position);
		if (distance < Config.WIZARD_ATTACK_RANGE)
			attack ();
		else
			chasePlayer ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals(Constant.TAG_BULLET)) {
			Bullet bullet = other.gameObject.GetComponent<Bullet>();
			hp -= bullet.getDamage();
			if (hp < 1) {
				anim.SetBool(Constant.ZOMBIE_ANIM_DEAD, true);
				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<Collider>());
				this.Invoke("DestroyWizard", Config.MONSTER_DESTROY_TIME);
			}
			Destroy(other.gameObject);
		}
	}

	void chasePlayer(){
		anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, true);
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);
		if (delayAfterAttack < 0) {
			transform.Translate (new Vector3 (0, 0, Config.WIZARD_MOVE_SPEED));
		}
	}

	void attack(){
		if (attackTime < 0) {
			anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, false);
			anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, true);

			Instantiate (summon, summonPos1.transform.position, Quaternion.identity);
			Instantiate (summon, summonPos2.transform.position, Quaternion.identity);
			Instantiate (summon, summonPos3.transform.position, Quaternion.identity);

			attackTime = Config.WIZARD_ATTACK_TIME;
			delayAfterAttack = Config.WIZARD_DELAY_AFTER_ATTACK;
		}
		else
			anim.SetBool (Constant.ZOMBIE_ANIM_IDLE, true);
	}

	void OnCollisionEnter(Collision other){
	}

	void DestroyWizard(){
		Destroy(this.gameObject);
	}
}
