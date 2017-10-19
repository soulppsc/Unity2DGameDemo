using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas Confirm;

	// Use this for initialization
	void Start () {
		Confirm.enabled = false;
	}

	public void StartGame () {
		SceneManager.LoadScene ("GameScene");
	}

	public void QuitGame () {
		Confirm.enabled = true;
		Application.Quit ();
	}

	public void YesBtn () {
		Application.Quit ();
	}

	public void NoBtn () {
		Confirm.enabled = false;
	}
}
