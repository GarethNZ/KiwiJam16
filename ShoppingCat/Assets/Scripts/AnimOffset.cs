using UnityEngine;
using System.Collections;

public class AnimOffset : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//GetComponent<Animator>()["Plane"].time = Random.Range(0.0f, GetComponent<Animation>()["Plane"].length);
		GetComponent<Animator>().ForceStateNormalizedTime(UnityEngine.Random.Range(0.0f, 1.0f));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
