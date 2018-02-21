using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronManager : MonoBehaviour {


	[SerializeField]
	private GameObject electronPrefab;
	public float spawnSpeed;
	public int maxElectrons = 6;
	public GameObject explosionEffect;
	// Use this for initialization
	void Start () {

		SpawnElectron ();
		InvokeRepeating ("SpawnElectron", spawnSpeed, spawnSpeed);
	}
	


	public void SpawnElectron(){

		GameObject babyElectron = (GameObject) Instantiate (electronPrefab, Waypoints.points [0], true);
		babyElectron.GetComponent<Electron> ().explosionEffect = explosionEffect;


	}
}
