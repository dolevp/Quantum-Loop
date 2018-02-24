using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {

	public Animator anim;
	public AudioSource gameOver;
	public bool isGameOver = false;
	public AdManager adManager;
	public ElectronManager eManager;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		adManager = GameObject.Find ("AdManager").GetComponent<AdManager> ();
	}
	
	public void GameOverAnim(){


		if(eManager.score > PlayerPrefs.GetInt("Best"))
			PlayerPrefs.SetInt("Best", eManager.score);
		isGameOver = true;
		anim.Play ("GameOver");
		gameOver.Play ();

	}
	public void RestartScene(){

		PlayerPrefs.SetInt ("AdCount", PlayerPrefs.GetInt ("AdCount") + 1);

		if (PlayerPrefs.GetInt ("AdCount") % 4 ==  0) {
			
			adManager.ShowInter ();
			Analytics.CustomEvent ("AdsPerUser: " + PlayerPrefs.GetInt("AdCount"));

		}
		SceneManager.LoadScene ("Main");

	}
}
