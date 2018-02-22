using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

		adManager.ShowInter ();
		SceneManager.LoadScene ("Main");

	}
}
