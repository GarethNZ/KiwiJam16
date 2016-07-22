using UnityEngine;
using System.Collections;

public class SpineTwistController : MonoBehaviour {

    public string input;
    public Transform jointToTwist;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float axisValue = Input.GetAxis(input);
        Vector3 rotation = Vector3.zero;
        rotation.x += axisValue;
        jointToTwist.Rotate(rotation);
    }
}
