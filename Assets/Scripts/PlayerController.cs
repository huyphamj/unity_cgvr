using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int moveSpeed = 10;
	public GameObject bullet;
	public GameObject bulletPosition;
	public const float ATTACK_SPEED = 0.5f;

	private bool isMoving = false;
	private Animator anim;
	private float atkCooldown = 0.5f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		atkCooldown -= Time.deltaTime;
		int degree = 0;
		isMoving = false;
		float hVal = Input.GetAxis("Horizontal");
		float vVal = Input.GetAxis("Vertical");

		if(hVal > 0 || hVal< 0) 
		{
			if (hVal < 0)
				degree = 270;
			else
				degree = 90;
			isMoving = true;
			transform.localEulerAngles = new Vector3(0, degree, 0);
			this.transform.Translate(0, 0, Mathf.Abs(hVal / moveSpeed));
		}
		if (vVal< 0 || vVal> 0)
		{
			if (vVal > 0)
				degree = 0;
			else
				degree = 180;
			isMoving = true;
			transform.localEulerAngles = new Vector3(0, degree, 0);
			this.transform.Translate(0, 0, Mathf.Abs(vVal / moveSpeed));
		}
		anim.SetBool("isMoving", isMoving);

		if (Input.GetKey(KeyCode.Space) && atkCooldown < 0)
		{
			atkCooldown = ATTACK_SPEED;
			Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	/*
	void Update () {
		int hDegree = 0;
		int vDegree = 0;
		int numberOfKeyPressed = 0;
		isMoving = false;
		float hVal = Input.GetAxis("Horizontal");
		float vVal = Input.GetAxis("Vertical");

		if(hVal > 0 || hVal < 0) 
		{
			if (hVal < 0)
				//left = true;
				hDegree = -90;
			else
				//right = true;
				hDegree = 90;
			numberOfKeyPressed = 1;
			isMoving = true;
			//this.transform.Translate(0, 0, Mathf.Abs(hVal / moveSpeed));
		}
		if (vVal < 0 || vVal > 0)
		{
			if (vVal > 0)
				vDegree += 0;
			else
				//down = true;
				vDegree += 180;
			isMoving = true;
			numberOfKeyPressed++;
			if (numberOfKeyPressed > 2)
				numberOfKeyPressed = 2;
			//this.transform.Translate(0, 0, Mathf.Abs(vVal / moveSpeed));
		}
		anim.SetBool("isMoving", isMoving);
		if (isMoving)
		{
			int degree = hDegree + vDegree;
			int angle = degree / numberOfKeyPressed;
			if (angle == 45 && hDegree < 0)
				angle = 225;
			transform.localEulerAngles = new Vector3(0, angle, 0);
			this.transform.Translate(0, 0, Mathf.Abs(Mathf.Abs(vVal / moveSpeed) > 0 ? vVal / moveSpeed : hVal / moveSpeed));
		}
	}
	*/
}
