using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <-- This is how to use the Unity UI functionality and directly access it!

public class scr_endscores : MonoBehaviour {

	public Text firstText;
	public Text secondText;
	public Text thirdText;

	int playerScore;

	int first;
	int second;
	int third;

	GameObject gameMaster;

	// Use this for initialization
	void Start () {
		gameMaster = GameObject.FindGameObjectWithTag ("GameMaster");

		playerScore = gameMaster.GetComponent<scr_game_master> ().score;

		first = scr_game_master.highScore1;
		second = scr_game_master.highScore2;
		third = scr_game_master.highScore3;

		firstText.text = first.ToString();
		secondText.text = second.ToString();
		thirdText.text = third.ToString();
	}
}
