using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {


	public ElectronManager eManager;
	// Use this for initialization
	void OnEnable () {

		Time.timeScale = 0;
		eManager.gamePaused = true;

	}
	
	// Update is called once per frame
	public void Resume () {

		Time.timeScale = 1;
		eManager.gamePaused = false;
		gameObject.SetActive (false);
		
	}



	public void BackToMenu(){

		if(eManager.score > PlayerPrefs.GetInt("Best"))
			PlayerPrefs.SetInt("Best", eManager.score);
		Time.timeScale = 1;
		eManager.gamePaused = false;
		SceneManager.LoadScene ("Menu");

	}
}
