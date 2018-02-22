using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Animator anim;
	public AudioSource gameOver;
	public bool isGameOver = false;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	}
	
	public void GameOverAnim(){


		isGameOver = true;
		anim.Play ("GameOver");
		gameOver.Play ();

	}
	public void RestartScene(){

		SceneManager.LoadScene ("Main");

	}
}
