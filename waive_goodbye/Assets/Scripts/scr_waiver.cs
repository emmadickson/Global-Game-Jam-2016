using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <-- This is how to use the Unity UI functionality and directly access it!

public class scr_waiver : MonoBehaviour {

	//Stamp sprite to place
	public GameObject stamp;

	GameObject myStamp; // This is the current paper's stamp.

	// To grab the next waiver
	public GameObject waiver;

	// Text files and their respective string arrays
	public TextAsset introText;
	public string[] introPhrases;

	public TextAsset outroText;
	public string[] outroPhrases;

	public TextAsset benignText;
	public string[] benignPhrases;

	public TextAsset timeBonusText;
	public string[] timeBonusPhrases;

	public TextAsset timeLossText;
	public string[] timeLossPhrases;

	public TextAsset threeDText;
	public string[] threeDPhrases;

	public TextAsset catText;
	public string[] catPhrases;

	public TextAsset soundText;
	public string[] soundPhrases;

	public TextAsset mouseSensitivityText;
	public string[] mouseSensitivityPhrases;

	public TextAsset messyText;
	public string[] messyPhrases;

	public TextAsset webCamText;
	public string[] webCamPhrases;

	public TextAsset quakeText;
	public string[] quakePhrases;

	public TextAsset raveText;
	public string[] ravePhrases;

	// Text box GameObjects
	public GameObject textBox;
	public Text theText;

	string waiverText;

	int chanceOfPunishment = 25;
	int chanceOfBonus = 35;
	int chanceOfPenalty = 50;

	bool isPunishment = false;
	bool isBonus = false;
	bool isTimePenalty = false;

	public string[] punishmentArray;
	string punishmentType;

	// Punishment prefabs
	public GameObject cat;
	public Object sound;
	public Object threeDDesk;
	public Object threeDVision;
	public Object rave;

	// SFX
	public AudioSource crumpleSound;
	public AudioSource punishmentSound;


	SpriteRenderer rend;
	Animator anim;

	public Sprite[] sprites;
	public Sprite crumpledSprite;

	void Start () {

		anim = GetComponent<Animator> ();
		rend = GetComponent<SpriteRenderer> ();

		rend.sprite = sprites [Random.Range (0, sprites.Length - 1)];

		crumpleSound = GetComponent<AudioSource> ();

		if (introText != null) {
			introPhrases = (introText.text.Split ('\n'));
		}

		if (outroText != null) {
			outroPhrases = (outroText.text.Split ('\n'));
		}

		if (benignText != null) {
			benignPhrases = (benignText.text.Split ('\n'));
		}

		if (threeDText != null) {
			threeDPhrases = (threeDText.text.Split ('\n'));
		}

		if (soundText != null) {
			soundPhrases = (soundText.text.Split ('\n'));
		}

		if (catText != null) {
			catPhrases = (catText.text.Split ('\n'));
		}

		if (mouseSensitivityText != null) {
			mouseSensitivityPhrases = (mouseSensitivityText.text.Split ('\n'));
		}

		if (messyText != null) {
			messyPhrases = (messyText.text.Split ('\n'));
		}

		if (timeBonusText != null) {
			timeBonusPhrases = (timeBonusText.text.Split ('\n'));
		}

		if (timeLossText != null) {
			timeLossPhrases = (timeLossText.text.Split ('\n'));
		}

		if (webCamText != null) {
			webCamPhrases = (webCamText.text.Split ('\n'));
		}

		if (quakeText != null) {
			quakePhrases = (quakeText.text.Split ('\n'));
		}

		if (raveText != null) {
			ravePhrases = (raveText.text.Split ('\n'));
		}

		// Dumps strings into the contract
		string phrase1 = introPhrases[Random.Range (0, introPhrases.Length - 1)];
		string phrase2 = benignPhrases [Random.Range (0, benignPhrases.Length - 1)];
		string phrase3 = benignPhrases [Random.Range (0, benignPhrases.Length - 1)];
		string phrase4 = outroPhrases [Random.Range (0, outroPhrases.Length - 1)];

		// If within chance of punishment...
		if (Random.Range (0, 100f) < chanceOfPunishment) {
			isPunishment = true;
			// Picks a type of type of punishment, stored as a string. Then goes into the arrays with the phrases.
			punishmentType = punishmentArray [Random.Range (0, punishmentArray.Length)];
			if (punishmentType == "Cat") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = catPhrases [Random.Range (0, catPhrases.Length - 1)];
				} else {
					phrase3 = catPhrases [Random.Range (0, catPhrases.Length - 1)];
				}
				Debug.Log ("Cat phrase called");
			}
			if (punishmentType == "3D") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = threeDPhrases [Random.Range (0, threeDPhrases.Length - 1)];
				} else {
					phrase3 = threeDPhrases [Random.Range (0, threeDPhrases.Length - 1)];
				}
			}
			if (punishmentType == "MouseSensitivity") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = mouseSensitivityPhrases [Random.Range (0, mouseSensitivityPhrases.Length - 1)];
				} else {
					phrase3 = mouseSensitivityPhrases [Random.Range (0, mouseSensitivityPhrases.Length - 1)];
				}
			}
			if (punishmentType == "Messy") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = messyPhrases [Random.Range (0, messyPhrases.Length - 1)];
				} else {
					phrase3 = messyPhrases [Random.Range (0, messyPhrases.Length - 1)];
				}
			}
			if (punishmentType == "Sound") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = soundPhrases [Random.Range (0, soundPhrases.Length - 1)];
				} else {
					phrase3 = soundPhrases [Random.Range (0, soundPhrases.Length - 1)];
				}
			}
			if (punishmentType == "Earthquake") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = quakePhrases [Random.Range (0, quakePhrases.Length - 1)];
				} else {
					phrase3 = quakePhrases [Random.Range (0, quakePhrases.Length - 1)];
				}
			}
			if (punishmentType == "Rave") {
				//Decides which phrase will be overwritten
				if (Random.Range (0, 1) <= .5f) {
					phrase2 = ravePhrases [Random.Range (0, ravePhrases.Length - 1)];
				} else {
					phrase3 = ravePhrases [Random.Range (0, ravePhrases.Length - 1)];
				}
			}
		}else if (Random.Range (0, 100f) < chanceOfBonus) {
			isBonus = true;
		
			if (Random.Range (0, 1) <= .5f) {
				phrase2 = timeBonusPhrases [Random.Range (0, timeBonusPhrases.Length - 1)];
			} else {
				phrase3 = timeBonusPhrases [Random.Range (0, timeBonusPhrases.Length - 1)];
			}
		}else if (Random.Range (0, 100f) < chanceOfPenalty) {
			isTimePenalty = true;

			if (Random.Range (0, 1) <= .5f) {
				phrase2 = timeLossPhrases [Random.Range (0, timeLossPhrases.Length - 1)];
			} else {
				phrase3 = timeLossPhrases [Random.Range (0, timeLossPhrases.Length - 1)];
			}
		}

		waiverText = phrase1 + "\n\n" + phrase2 + phrase3 + "\n\n" + phrase4;
		Debug.Log (waiverText);
		theText.text = waiverText;

	}

	//Allows you to order the placement of the papers from the Game Master script
	/*void setPlacement(int x){
		// To find out which spot the paper will be in. 1 = left, 2 = center, 3 = right
		anim.SetInteger("waiverSpot", x);
		Debug.Log (" I set placement");
	}*/

	// Copied from startup script. This works similarly and places a stamp, then triggers the exit animation.
	void OnMouseDown(){
		//Stamps page
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		myStamp = Instantiate (stamp, mousePos, Quaternion.identity);
		myStamp.transform.SetParent(gameObject.transform);

		if (isPunishment) {
			punishmentSound.Play ();
			performPunishment ();
		}

		// Adds point for passing paper
		GameObject gameMaster = GameObject.FindGameObjectWithTag ("GameMaster");
		if (!isPunishment && !isTimePenalty) {
			gameMaster.GetComponent<scr_game_master> ().addPoints (1);
		}
		if (isBonus) {
			gameMaster.GetComponent<scr_game_master> ().addTime();
		}
		if (isTimePenalty) {
			gameMaster.GetComponent<scr_game_master> ().removeTime();
		}

		anim.SetTrigger ("Exit");
	}

	public void trashPhase(){
		rend.sprite = crumpledSprite;
		crumpleSound.Play();
		theText.text = "";
		anim.SetTrigger ("Trash");
	}

	void destroyThis(){
		
		//Instantiate (waiver, new Vector3(-22f, 0f, 0f), Quaternion.identity);
		Destroy (gameObject);
	}

	void performPunishment(){
		if (punishmentType == "Cat") {
			Debug.Log ("Got into performPunishment() Cat if statement");
			if(GameObject.FindGameObjectWithTag("Cat") == null){
				Instantiate (cat, new Vector3(0f, 0f, 0f), Quaternion.identity);
					Debug.Log("Instantiate Cat");
			}
		}
		if (punishmentType == "3D") {
			Instantiate (threeDDesk, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Instantiate (threeDVision, new Vector3(0f, 0f, 0f), Quaternion.identity);
		}
		if (punishmentType == "Earthquake") {
			GameObject gameMaster = GameObject.FindGameObjectWithTag ("GameMaster");
			gameMaster.GetComponent<scr_game_master> ().enableEarthquake();
		}
		if (punishmentType == "Messy") {
			GameObject gameMaster = GameObject.FindGameObjectWithTag ("GameMaster");
			gameMaster.GetComponent<scr_game_master> ().rotatePapers ();
		}
		if (punishmentType == "Sound") {
			Instantiate (sound, new Vector3(0f, 0f, 0f), Quaternion.identity);
		}
		if (punishmentType == "Rave") {
			Instantiate (rave, new Vector3(0f, 0f, 0f), Quaternion.identity);
		}
	}
}
