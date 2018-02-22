using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour {


	public Animator startAnim;

	void Update(){


		if (Input.GetMouseButton (0))
			startAnim.Play ("Start");

	}
	

}
