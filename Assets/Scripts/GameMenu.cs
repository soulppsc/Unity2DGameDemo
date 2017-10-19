﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public Canvas Confirm;
	public Canvas Menu;

	// Use this for initialization
	void Start () {
		Confirm.enabled = false;
		Menu.enabled = false;
	}

	public void MenuBtn () {
		Menu.enabled = true;
	}

	public void BackToMainMenu () {
		SceneManager.LoadScene ("MenuScene");
	}

	public void BackToDesktop () {
		Confirm.enabled = true;
	}

	public void YesBtn () {
		Application.Quit ();
	}

	public void NoBtn () {
		Confirm.enabled = false;
	}

	public void escBtn () {
		Menu.enabled = false;
	}

}
