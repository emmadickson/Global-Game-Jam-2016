using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_game_master : MonoBehaviour {

	public GameObject waiver;
	GameObject currentWaiver;

	// Scoring and timing objects and text boxes
	public Text scoreNoteText;
	public GameObject phoneTextBox;// This has the ticking sfx, destroy it on end.
	public Text phoneTimeText;

	// Gameplay variables
	public int score = 0;
	public float timer;
	public float timeBonusAmount;
	public float timePenaltyAmount;

	public static int highScore1 = 0;
	public static int highScore2 = 0;
	public static int highScore3 = 0;
	//static int highScore1;

	// Punishment variables
	bool messyPapers = false;
	bool earthquakeMode = false;

	// This keeps track of the progress of the game.
	int turns;

	// SFX
	public AudioSource pointSound;
	public AudioSource hurtSound;
	public AudioSource explosionSound;

	// Screenshake
	Vector3 originalCameraPosition;
	float shakeAmt = .03f;
	public Camera mainCamera;

	// Ending variables
	public GameObject endPaperPrefab;

	void Start () {
		Instantiate (waiver, new Vector3(-22f, 0f, 0f), Quaternion.identity);
		scoreNoteText.text = "0";
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		// Timer counting
		timer = timer - Time.deltaTime;
		phoneTimeText.text = timer.ToString ().Substring (0, 4);
		//Debug.Log (timer);

		if (timer <= 0f) {
			Destroy (currentWaiver);
			timer = 0;
			if(GameObject.FindGameObjectWithTag("EndPaper") == null){
				/*int sortArray[4];
				sortArray[0] = highScore1;
				sortArray[1] = highScore2;
				sortArray[2] = highScore3;
				sortArray[3] = score;

				for ( int i = 0; i < 4; i++){
					for (int j = new; j > i; j--){
						if (sortArray[j] > sortArray[j+1]){
							temp = sortArray[j+1];
							sortArray[j+1] = sortArray[j];
							sortArray[j] = temp;
						}
					}
				}*/

				Instantiate (endPaperPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			};/*
			Destroy (GameObject.FindGameObjectWithTag ("Rave"));
			Destroy (GameObject.FindGameObjectWithTag ("Sound"));
			Destroy (GameObject.FindGameObjectWithTag ("3D"));
			Destroy (GameObject.FindGameObjectWithTag ("Popup"));*/
		}

		if(GameObject.FindGameObjectWithTag("Waiver") == null){
			if (!messyPapers) {
				currentWaiver = Instantiate (waiver, new Vector3 (-22f, 0f, 0f), Quaternion.identity);
				Debug.Log ("Score : " + score);
				//score++;
			} else {
				currentWaiver = Instantiate (waiver, new Vector3 (-22f, 0f, 0f), Quaternion.Euler(0f, 0f, (Random.Range(-50f, 50f))));
				//score++;
			}
		}

		//If earthquake punishment
		if (earthquakeMode) {
			screenShake ();
		}

		// Restart controls
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}

	// For subtracting for things like trashing (making a net 0 gain for the waiver). Can play with things like point penalties too.
	public void addPoints(int addition){
		score = score + addition;
		if (addition > 0) {
			pointSound.Play ();
		}
		scoreNoteText.text = score.ToString();
	}

	// For time bonus phrases
	public void addTime(){
		timer = timer + timeBonusAmount;
	}

	// For time penalty phrases
	public void removeTime(){
		hurtSound.Play ();
		timer = timer - timePenaltyAmount;
	}

	// For "messy/organization" punishment
	public void rotatePapers(){
		messyPapers = true;
	}

	public void enableEarthquake(){
		earthquakeMode = true;
	}

	void screenShake(){
		if (shakeAmt > 0) {
			float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			if (Random.Range (0, 1) <= .5f) {
				pp.y += quakeAmt;
			} else {
				pp.y -= quakeAmt;
			}
			if (Random.Range (0, 1) <= .5f) {
				pp.x += quakeAmt;
			} else {
				pp.x -= quakeAmt;
			}
			mainCamera.transform.position = pp;
		}
	}

	void endPhase(){
		Destroy (currentWaiver);
		//Destroy (phoneTextBox);
	}
}
