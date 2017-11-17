using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public Vector2 jumpForce = new Vector2(0,10);
	public Transform groundCheck;
	public Rigidbody2D bullet;
	public Transform shotPosition;

	private Rigidbody2D rb;
	private Animator anim;
	private bool grounded;//是否在地面上
	private bool falling;//是否在坠落
	private float coolDownTime;//射击间隔
	private bool facingRight = true;//主体是否朝右
	private bool jump = false;//是否按了跳跃
	private float h;//横轴输入值
	private float OriY;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		OriY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//玩家对象的控制
		h = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(h));
		//rb.velocity = new Vector2 (walkSpeed, rb.velocity.y);
		rb.velocity = new Vector2 (h * walkSpeed, rb.velocity.y);

		//玩家的落地检测
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		anim.SetBool ("Grounded", grounded);

		//当使用跳跃
		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}
		
		//当使用发射键
		coolDownTime += Time.deltaTime;
		if (Input.GetButton ("Fire1") && coolDownTime >= 0.3f && !EventSystem.current.IsPointerOverGameObject ()) {
		
			Instantiate (bullet, shotPosition.position, Quaternion.identity);
			coolDownTime = 0;
		}

	}

	void FixedUpdate () {

		if (jump) {
			anim.SetTrigger ("Jump");
			rb.AddForce (jumpForce);
			jump = false;

		}

		if (rb.velocity.y < 0)
			anim.SetTrigger ("Falling");

		//左右运动时翻转
		if (h < 0 && facingRight)
			Flip ();
		else if (h > 0 && !facingRight)
			Flip ();

		zlyCameraAlongWith.AlongWith (Camera.main, transform, transform.position.y, 3, 6, 1);
	}
		

	void Flip () {//翻转主体对象
		facingRight = !facingRight;
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;
	}
		
}
