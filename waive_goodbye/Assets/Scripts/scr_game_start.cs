using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_game_start : MonoBehaviour {

	public GameObject gameMaster;
	public GameObject stamp;

	Animator anim;

	void OnMouseDown(){
		//StartCoroutine (TimerCoroutine ());
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		GameObject myStamp = Instantiate (stamp, mousePos, Quaternion.identity);
		myStamp.transform.SetParent(gameObject.transform);
		anim.SetTrigger ("Exit");
	}

	/*IEnumerator TimerCoroutine(){
		yield return new WaitForSeconds(.5f);
		Instantiate (gameMaster, Vector3.zero, Quaternion.identity);
		Destroy (gameObject);
	}*/

	void destroyThis(){
		Instantiate (gameMaster, Vector3.zero, Quaternion.identity);
		Destroy (gameObject);
	}

	void Start(){
		anim = GetComponent<Animator> ();
	}
}
