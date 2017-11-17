using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	float t;

	// Use this for initialization
	void Start () {
		t = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x,t + Mathf.PingPong(Time.time * 0.3f,0.2f));
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
