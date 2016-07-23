using UnityEngine;
using System.Collections;

public class TorsoTwist : MonoBehaviour {

    public string inputAxis = "";

    // Both directions (+ & -)
    public float MAX_ROTATION = 90.0f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(0, MAX_ROTATION * Input.GetAxis(inputAxis), 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation, 0.5f); ;
    }
}
