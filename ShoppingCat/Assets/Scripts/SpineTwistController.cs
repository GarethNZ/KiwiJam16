using UnityEngine;

public class SpineTwistController : MonoBehaviour {

    public string leftRightInputAxis = "Horizontal";
    public string forwardBackInputAxis = "Vertical";

    // Both directions (+ & -)
    public float MAX_ROTATION = 45.0f;
    public float ROTATION_SPEED = 180.0f; // Full range in about 2 seconds
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newRotation = transform.localRotation.eulerAngles;
        newRotation.z = MAX_ROTATION * Input.GetAxis(leftRightInputAxis);
        newRotation.x = MAX_ROTATION * Input.GetAxis(forwardBackInputAxis);
        
        transform.localRotation = Quaternion.Euler(newRotation);

    }

    private float getRotationForSingleAxis(float currentAngle, string inputAxis)
    {
        float rotationValue = Input.GetAxis(inputAxis);

        if (rotationValue != 0)
        {
            float rangeFixedCurrentRotation = currentAngle;
            if (rangeFixedCurrentRotation > 180)
            {
                rangeFixedCurrentRotation -= 360f;
            }

            if (rotationValue > 0 && rangeFixedCurrentRotation > MAX_ROTATION)
            {
                rotationValue = 0f;
            }
            else if (rotationValue < 0 && rangeFixedCurrentRotation < -MAX_ROTATION)
            {
                rotationValue = 0f;
            }
            return rotationValue;
        }
        return 0f;
    }
}
