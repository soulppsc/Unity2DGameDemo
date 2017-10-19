using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public float countDownTime = 3f;
	public bool startGame = false;
	private float sumTime;
	private Text text;

	// Use this for initialization
	void Start () {
		sumTime = countDownTime;
		text = GetComponent<Text> ();
		StartCoroutine (StartCountDown ());
		Debug.Log (Time.realtimeSinceStartup);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartCountDown () {
		while (sumTime > 0) {
			text.text = ((int)sumTime).ToString();
			sumTime--;
			yield return new WaitForSeconds(1);
		}
		startGame = true;
		this.gameObject.SetActive (false);
	}
}
