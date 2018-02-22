using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElectronManager : MonoBehaviour {


	[SerializeField]
	private GameObject electronPrefab;
	public int maxElectrons = 6;
	private float electronSpeed = 3f;
	public GameObject explosionEffect;
	public int numberOfSpots,score, levelSpots = 0;
	public Text scoreText;
	public GameObject[] launcherSpots;
	public List<GameObject> electrons;
	private Vector2 newLocation;
	public AudioSource swoosh, nextlevel;
	private Vector2 startPosition;
	bool gameOver;

	// Use this for initialization
	void Start () {



		startPosition = new Vector2(transform.position.x, transform.position.y - 0.37f);
		newLocation = transform.position;
		launcherSpots = new GameObject[transform.childCount];
		levelSpots = 4;

		SetSpots ();



	}

	void Update(){

		transform.position = Vector2.MoveTowards (transform.position, newLocation, 2.7f * Time.deltaTime);

		if (Input.GetMouseButtonDown (0) && numberOfSpots < levelSpots && !Camera.main.GetComponent<GameManager>().isGameOver) {

			RemoveSpot ();
			SpawnElectron ();


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



		swoosh.Play ();
		electrons [numberOfSpots] = (GameObject)Instantiate (electronPrefab, Waypoints.points [0], true);
		electrons[numberOfSpots].GetComponent<Electron> ().explosionEffect = explosionEffect;
		electrons[numberOfSpots].GetComponent<Electron> ().eManager = this;
		electrons [numberOfSpots].GetComponent<Electron> ().speed = electronSpeed;
		electrons [numberOfSpots].GetComponent<SpriteRenderer> ().color = launcherSpots [numberOfSpots].GetComponent<SpriteRenderer> ().color;
		numberOfSpots++;
		AddScore ();

		if (numberOfSpots >= levelSpots)
			NextStep ();


	}

	public void RemoveSpot(){

		//Remove the spot
		launcherSpots [numberOfSpots].SetActive (false);
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

	public void NextStep(){


		//play next level audio
		nextlevel.Play ();
		//Restart Game
		// -------------------------

		//Reset current active spots count
		numberOfSpots = 0;

		//Make it harder
		if(levelSpots<=8)
			levelSpots++;
		
		//Destroy Electrons
		foreach (GameObject go in electrons) {

			Destroy (go);

		}

		//Set spots
		SetSpots ();

		//Set launcher position to starting position
		newLocation = startPosition;


		//Make it harder
		electronSpeed += 0.9f;

	}






}
