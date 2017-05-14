using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <-- This is how to use the Unity UI functionality and directly access it!


public class scr_textbox_manager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public void inputWaiverText(string waiverText){
		theText.text = waiverText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
