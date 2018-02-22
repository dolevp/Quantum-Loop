using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronManager : MonoBehaviour {


	[SerializeField]
	private GameObject electronPrefab;
	public int maxElectrons = 6;
	public GameObject explosionEffect;
	public int numberOfSpots,score, levelSpots = 0;
	public Text scoreText;
	public GameObject[] launcherSpots;
	public List<GameObject> electrons;
	private Vector2 newLocation;
	private Vector2 startPosition;
	// Use this for initialization
	void Start () {

		startPosition = transform.position;
		newLocation = transform.position;
		launcherSpots = new GameObject[transform.childCount];
		levelSpots = 4;

		SetSpots ();



	}

	void Update(){

		transform.position = Vector2.MoveTowards (transform.position, newLocation, 2.7f * Time.deltaTime);

		if (Input.GetMouseButtonDown (0) && numberOfSpots < levelSpots) {


			SpawnElectron ();
			RemoveSpot ();

		}

	}

	void SetSpots(){

		for (int i = 0; i < launcherSpots.Length; i++) {

			launcherSpots [i] = transform.GetChild (i).gameObject;
			if (i < levelSpots)
				launcherSpots [i].SetActive (true);
		}

	}

	public void SpawnElectron(){



//		GameObject babyElectron = (GameObject)Instantiate (electronPrefab, Waypoints.points [0], true);
//		babyElectron.GetComponent<Electron> ().explosionEffect = explosionEffect;
//		babyElectron.GetComponent<Electron> ().eManager = this;
		electrons [numberOfSpots] = (GameObject)Instantiate (electronPrefab, Waypoints.points [0], true);
		electrons[numberOfSpots].GetComponent<Electron> ().explosionEffect = explosionEffect;
		electrons[numberOfSpots].GetComponent<Electron> ().eManager = this;
		numberOfSpots++;
		AddScore ();

		if (numberOfSpots >= levelSpots)
			RestartGame ();


	}

	public void RemoveSpot(){

		//Remove the spot
		launcherSpots [numberOfSpots - 1].SetActive (false);
		//Make launcher go up a bit
		newLocation = new Vector2 (transform.position.x, transform.position.y + .76f);



	}

	public void AddScore(){

		score++;
		scoreText.text = "" + score;


	}

	public void ResetScore(){

		score = 0;
		scoreText.text = "" + score;

	}

	public void RestartGame(){

		//Restart
		foreach (GameObject go in electrons) {

			Destroy (go);

		}

		SetSpots ();

		transform.position = startPosition;

		//Make it harder

	}




}
