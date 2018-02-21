using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour {

	public float speed = 12f;

	private Transform target;
	private int currentPoint = 0;
	public GameObject explosionEffect;
	bool isNew = true;

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


		if (Input.GetMouseButtonDown (0) && !isNew) {

			if(Vector2.Distance(transform.position, Waypoints.points[0].position) <= 1f)

			{

				Explode ();

			}

		}
	}



	void GetNextWaypoint(){

		if (currentPoint >= Waypoints.points.Length - 1) 
			currentPoint = 0;



		else
			currentPoint++;
		target = Waypoints.points [currentPoint];

		if(currentPoint >= 10)
			isNew = false;

	}

	void Explode(){

		Destroy (Instantiate (explosionEffect), 3.3f);
		Destroy (gameObject);
	}
}
