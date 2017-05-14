using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_trash : MonoBehaviour {

	public GameObject waiver;

	void OnMouseEnter(){
		// When mousing over trash can, widen it 
		transform.localScale += new Vector3(.5f, .5f, 0f);
	}
	void OnMouseExit(){
		// When mousing away, shrink it 
		transform.localScale -= new Vector3(.5f, .5f, 0f);
	}
	void OnMouseDown(){
		// Click on to enter trashing phase.

		//Subtracts score
		GameObject gameMaster = GameObject.FindGameObjectWithTag ("GameMaster");
		gameMaster.GetComponent<scr_game_master> ().addPoints (0);
		// Trashes on waiver object
		waiver.GetComponent<scr_waiver> ().trashPhase ();
		Destroy (gameObject);
	}
}
