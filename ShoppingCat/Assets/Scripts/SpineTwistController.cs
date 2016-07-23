using UnityEngine;

public class SpineTwistController : MonoBehaviour {

    public string leftRightInputAxis = "Horizontal";
    public string forwardBackInputAxis = "Vertical";

    public bool isArm = false;

    // Both directions (+ & -)
    public float MAX_ROTATION = 45.0f;
    public float ROTATION_SPEED = 180.0f; // Full range in about 2 seconds
    
	// Use this for initialization
	void Start () {
	
	}

    private float getWobbleValue()
    {
        return Random.Range(-5f, 5f);
    }

    private Quaternion wobbleTarget;
    private Quaternion lastWobbleTarget;
    private float lastWobbleUpdate;
    private float WOBBLE_RATE = 1.0f;
    private void updateWobbleTarget()
    {
        wobbleTarget = Quaternion.Euler(getWobbleValue(), getWobbleValue(), getWobbleValue());
    }

    // Update is called once per frame
	void Update () {
        // TODO: surely there is an easier way of doing all of this
        Vector3 newRotation = Vector3.zero;
        newRotation.z = MAX_ROTATION * Input.GetAxis(leftRightInputAxis);
        if (isArm)
        {
            newRotation.y = MAX_ROTATION * Input.GetAxis(forwardBackInputAxis);
        } else
        {
            newRotation.x = MAX_ROTATION * Input.GetAxis(forwardBackInputAxis);
        }

        //Debug.Log("start = " + transform.localRotation.eulerAngles + " newRotation = " + newRotation);

        Quaternion rotation = Quaternion.Euler(newRotation);
        // Slow rate of getting there:
        rotation = Quaternion.Lerp(transform.localRotation, rotation, 0.5f);
        // Add Wobble
        if (Time.time > lastWobbleUpdate + WOBBLE_RATE)
        {
            lastWobbleUpdate = Time.time;
            lastWobbleTarget = wobbleTarget;
            updateWobbleTarget();
        }
        rotation *= Quaternion.Slerp(lastWobbleTarget, wobbleTarget, ((Time.time - lastWobbleUpdate) % WOBBLE_RATE) / WOBBLE_RATE);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 0.5f); ;

    }
}
