using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	bool ready = false;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonUp ("Fire1")) {
			GetComponent<Animator> ().SetTrigger ("startGame");
			ready = true;
		}

		if (Input.GetButton ("Fire1") && ready == true) {
			Application.LoadLevel("main");

		}
	}

}

