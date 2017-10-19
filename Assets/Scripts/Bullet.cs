using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float flySpeed = 5.0f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 point = ray.origin;
		point.z = 0;
		Vector3 dir = point - transform.position;
		rb.velocity = new Vector2 (dir.normalized.x, dir.normalized.y) * flySpeed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()  
	{  
		Destroy (this.gameObject);
	}  
}
