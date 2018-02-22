using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Text bestText;
	void Start(){

		DontDestroyOnLoad (gameObject);
		bestText.text = "" + PlayerPrefs.GetInt ("Best");
	}

	public void StartGame(){


		SceneManager.LoadScene ("Main");

	}

}
