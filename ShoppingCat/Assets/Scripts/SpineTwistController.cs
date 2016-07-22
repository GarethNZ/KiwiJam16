using UnityEngine;
using System.Collections;

public class SpineTwistController : MonoBehaviour {

    public string input;

    // Both directions (+ & -)
    private float MAX_ROTATION = 45.0f;
    private float ROTATION_SPEED = 45.0f; // Full range in about 2 seconds
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float axisValue = Input.GetAxis(input);
        Vector3 rotation = Vector3.zero;
        
        float rangeFixedCurrentRotation = transform.localRotation.eulerAngles.z;
        if (rangeFixedCurrentRotation > 180)
        {
            rangeFixedCurrentRotation -= 360f;
        }

        if (axisValue != 0)
            Debug.Log("Rotation: " + rangeFixedCurrentRotation);

        if (axisValue > 0 && rangeFixedCurrentRotation > MAX_ROTATION) {
            axisValue = 0f;
        }
        else if (axisValue < 0 && rangeFixedCurrentRotation < -MAX_ROTATION)
        {
            axisValue = 0f;
        }
        rotation.z = axisValue * ROTATION_SPEED * Time.deltaTime;
        transform.Rotate(rotation);

    }
}
