using UnityEngine;

public class SpineTwistController : MonoBehaviour {

    public string leftRightInputAxis = "Horizontal";
    public string forwardBackInputAxis = "Vertical";

    public bool isArm = false;

    // Both directions (+ & -)
    public float MAX_ROTATION = 45.0f;
    public float ROTATION_SPEED = 180.0f; // Full range in about 2 seconds

    private float xNoiseOffset;
    private float yNoiseOffset;
    private float zNoiseOffset;
    // Use this for initialization
    void Start()
    {
        xNoiseOffset = Random.Range(0, 100f);
        yNoiseOffset = Random.Range(0, 100f);
        zNoiseOffset = Random.Range(0, 100f);
    }

    private float NOISE_AMPLITUDE = 5.0f;

    private float getNoise(float offset)
    {
        return NOISE_AMPLITUDE * (Mathf.PerlinNoise(Time.time + offset, 0) - 0.5f);
    }

    private Quaternion getNoiseVector()
    {
        return Quaternion.Euler(getNoise(xNoiseOffset), getNoise(yNoiseOffset), getNoise(zNoiseOffset));
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
        rotation *= getNoiseVector();

        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 0.5f); ;

    }
}
