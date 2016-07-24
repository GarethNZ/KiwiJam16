using UnityEngine;
using System.Collections;

public class FeetController : MonoBehaviour {
    public InputRandomizer.DualInputSet setOfInputsLeft;
    private InputRandomizer.DualAxisInput leftInputs;

    public InputRandomizer.DualInputSet setOfInputsRight;
    private InputRandomizer.DualAxisInput rightInputs;

    public delegate void SteppedTooFar();
    public static event SteppedTooFar onOverStride;

    public GameObject upperBody;
    public GameObject leftFoot;
    public GameObject rightFoot;

    private const float MAX_SPEED = 10.0f;
    //private Vector3 MOVE_FORWARD = new Vector3(0, 0, MAX_SPEED);

    private const float MAX_STRIDE = 10.0f;

    //private Vector3 VERTICAL_SPEED = new Vector3(0, 2.0f, 0);
    private const float MAX_HEIGHT = 5.0f;


    private float leftNoiseOffset;
    private float rightNoiseOffset;
    // Use this for initialization
    void Start() {
        leftNoiseOffset = Random.Range(0, 100f);
        rightNoiseOffset = Random.Range(0, 100f);

        leftInputs = InputRandomizer.inputMaps[setOfInputsLeft];
        rightInputs = InputRandomizer.inputMaps[setOfInputsRight];
    }

    // Update is called once per frame
    void Update() {
        bool rightMoved = updateFoot(rightFoot, rightInputs.horizontal, rightInputs.vertical, rightNoiseOffset);
        bool leftMoved = updateFoot(leftFoot, leftInputs.horizontal, leftInputs.vertical, leftNoiseOffset);

        float distanceBetweenFeet = Vector3.Distance(leftFoot.transform.position, rightFoot.transform.position);
        if (distanceBetweenFeet >= MAX_STRIDE)
        {
            Vector3 vect = leftFoot.transform.position - rightFoot.transform.position;
            vect = vect.normalized;
            vect *= (distanceBetweenFeet - MAX_STRIDE);

            if (leftMoved && rightMoved)
            {
                vect /= 2;
                leftFoot.transform.position -= vect;
                rightFoot.transform.position += vect;
            }
            else if (leftMoved)
            {
                leftFoot.transform.position -= vect;
            }
            else if (rightMoved)
            {
                rightFoot.transform.position += vect;
            }


            Debug.LogError("Feet too far apart, event onOverStride triggered");
            // TODO: Trigger event
            if (onOverStride != null)
            {
                onOverStride();
            }
        }

        Vector3 upperBodyTarget = Vector3.Lerp(rightFoot.transform.position, leftFoot.transform.position, 0.5f);
        upperBodyTarget.y = upperBody.transform.position.y;
        //Vector3.Lerp
        //upperBodyTarget.z = (rightFoot.transform.position.z + leftFoot.transform.position.z) / 2;
        //upperBodyTarget.x = (rightFoot.transform.position.x + leftFoot.transform.position.x) / 2;
        Debug.Log("upperBodyTarget = " + upperBodyTarget + " left = " + leftFoot.transform.position + " right = " + rightFoot.transform.position);
        upperBody.transform.position = Vector3.MoveTowards(upperBody.transform.position, upperBodyTarget, MAX_SPEED * Time.deltaTime);

    }

    private float NOISE_AMPLITUDE = 0.5f;

    private float getNoise(float offset)
    {
        return NOISE_AMPLITUDE * (Mathf.PerlinNoise(Time.time + offset, 0) - 0.5f);
    }
    // Return if the foot is moving
    private bool updateFoot(GameObject foot, string leftRightAxis, string forwardBackAxis, float noiseOffset)
    {
        Vector3 movement = Vector3.zero;
        movement.x = -Input.GetAxis(leftRightAxis) + getNoise(noiseOffset);
        movement.z = Input.GetAxis(forwardBackAxis) + getNoise(noiseOffset);
        foot.transform.Translate(movement * MAX_SPEED * Time.deltaTime);

        float xPos = Mathf.Clamp(foot.transform.position.x, -10f, 13f);
        float zPos = Mathf.Clamp(foot.transform.position.z, -76f, 110f);
        foot.transform.position = new Vector3(xPos, foot.transform.position.y, zPos);

        return Input.GetAxis(leftRightAxis) != 0f || Input.GetAxis(forwardBackAxis) != 0f;
    }

    private bool feetAreTooFarApart()
    {
        return Vector3.Distance(leftFoot.transform.position, rightFoot.transform.position) >= MAX_STRIDE;
    }
}
