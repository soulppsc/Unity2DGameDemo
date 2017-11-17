using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float MoveDistance;
	public float MoveSpeed;
	private float firstPosX;
	private int health = 3;

	// Use this for initialization
	void Start () {
		firstPosX = transform.position.x;
	}
	
	// Update is called once per frame

	void Update() {
		if (health == 0) {
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate () {
		transform.position = new Vector3 (firstPosX + Mathf.PingPong (Time.time * MoveSpeed, MoveDistance), transform.position.y);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.CompareTag("Bullet"))
			Destroy (other.gameObject);
		health--;
	}
}
