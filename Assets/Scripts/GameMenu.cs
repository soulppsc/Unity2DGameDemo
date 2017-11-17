using System.Collections;
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
		Time.timeScale = 0;
	}

	public void BackToMainMenu () {
		SceneManager.LoadScene ("MenuScene");
		Time.timeScale = 1;
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
		Time.timeScale = 1;
	}

}
