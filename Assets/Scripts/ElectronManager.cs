using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronManager : MonoBehaviour {


	[SerializeField]
	private GameObject electronPrefab;
	public float spawnSpeed;
	public int maxElectrons = 6;
	public GameObject explosionEffect;
	public int score = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {

		spawnSpeed = 2.1f;

		SpawnElectron ();



	}
	


	public void SpawnElectron(){

		GameObject babyElectron = (GameObject) Instantiate (electronPrefab, Waypoints.points [0], true);
		babyElectron.GetComponent<Electron> ().explosionEffect = explosionEffect;
		babyElectron.GetComponent<Electron> ().eManager = this;
		babyElectron.GetComponent<Electron> ().speed += (float)score / 45;
		Invoke ("SpawnElectron", spawnSpeed);


	}

	public void AddScore(){

		score++;
		scoreText.text = "" + score;


		if (score >= 3 && score <= 10)
			spawnSpeed = 1.6f;
		if (score >= 11 && score <= 25)
			spawnSpeed = 1.1f;
		if (score >= 26 && score <= 35)
			spawnSpeed = .8f;
		if (score >= 36 && score <= 52)
			spawnSpeed = .7f;
		


	}


}
