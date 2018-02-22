using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour {

	public float speed = 3f;

	private Transform target;
	private int currentPoint = 0;
	public ElectronManager eManager;
	public GameObject explosionEffect;

	// Use this for initialization
	void Start () {



		target = Waypoints.points [0];
	}
	

	void Update () {

		Vector2 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if(Vector2.Distance(transform.position, target.position) <= 0.15f)

		{
			
				GetNextWaypoint();

		}

	}

	void OnCollisionEnter2D(Collision2D col) {

		Explode ();


	}


	void GetNextWaypoint(){

		if (currentPoint >= Waypoints.points.Length - 1) 
			currentPoint = 0;



		else
			currentPoint++;
		target = Waypoints.points [currentPoint];

	
	}

	void Explode(){

		Destroy(Instantiate(explosionEffect),3.6f);
		Destroy (gameObject);

	}
}
