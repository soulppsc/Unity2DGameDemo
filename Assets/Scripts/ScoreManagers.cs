using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagers : MonoBehaviour {

	private Text text;
	private CountDown countDown;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		countDown = GameObject.Find ("CountDown").GetComponent<CountDown> ();
		text.text = "你的得分:";
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown.startGame) {
			text.text = "你的得分:" + (int)(Time.timeSinceLevelLoad * 100 - countDown.countDownTime * 100);
		}
	}
}
