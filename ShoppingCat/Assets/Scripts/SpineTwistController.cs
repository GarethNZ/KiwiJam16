using UnityEngine;

public class SpineTwistController : MonoBehaviour {

    public string rotationInputAxis;


    // Both directions (+ & -)
    public float MAX_ROTATION = 45.0f;
    public float ROTATION_SPEED = 180.0f; // Full range in about 2 seconds
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rotationValue = Input.GetAxis(rotationInputAxis);


        if(rotationValue != 0)
        {
            Vector3 rotation = Vector3.zero;

            float rangeFixedCurrentRotation = transform.localRotation.eulerAngles.z;
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
            rotation.z = rotationValue * ROTATION_SPEED * Time.deltaTime;
            transform.Rotate(rotation);
        }

        /*float verticalValue = Input.GetAxis(verticalInputAxis);

        if (verticalValue != 0)
        {
            transform
        }
        */

    }
}
