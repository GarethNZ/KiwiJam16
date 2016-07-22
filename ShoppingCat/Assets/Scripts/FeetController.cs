using UnityEngine;
using System.Collections;

public class FeetController : MonoBehaviour {

    public delegate void SteppedTooFar();
    public static event SteppedTooFar onOverStride;

    public GameObject upperBody;
    public GameObject leftFoot;
    public GameObject rightFoot;

    private const float MAX_SPEED = 5.0f;
    private Vector3 MOVE_FORWARD = new Vector3(0, 0, MAX_SPEED);

    private const float MAX_STRIDE = 10.0f;

    private Vector3 VERTICAL_SPEED = new Vector3(0, 2.0f, 0);
    private const float MAX_HEIGHT = 5.0f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // TODO: Only allow one foot moving at a time.
        if (rightFoot.transform.position.y > 0)
        {
            updateFoot(rightFoot, "Fire1");
        } else if (leftFoot.transform.position.y > 0)
        {
            updateFoot(leftFoot, "Fire2");
        }
        else
        {
            // TODO: Ensure only one starts in one frame
            updateFoot(rightFoot, "Fire1");
            updateFoot(leftFoot, "Fire2");
        }

        Vector3 upperBodyTarget = upperBody.transform.position;
        upperBodyTarget.z = (rightFoot.transform.position.z + leftFoot.transform.position.z) / 2;
        upperBody.transform.position = Vector3.MoveTowards(upperBody.transform.position, upperBodyTarget, MAX_SPEED * Time.deltaTime);

        if (Vector3.Distance(leftFoot.transform.position, rightFoot.transform.position) >= MAX_STRIDE)
        {
            // TODO: Trigger event
            if (onOverStride != null)
            {
                onOverStride();
            }
        }
    }

    // Return if the foot is moving
    private bool updateFoot(GameObject foot, string input)
    {
        Vector3 movement = Vector3.zero;
        bool inputPressed = Input.GetButton(input);
        movement += getVerticalSpeed(foot.transform.position.y, inputPressed);
        if (movement.y != 0 || inputPressed)
        {
            movement += MOVE_FORWARD;
        }

        foot.transform.Translate(movement * Time.deltaTime);
        return movement != Vector3.zero;
    }

    // Assumes 0 == ground
    private Vector3 getVerticalSpeed(float currentHeight, bool buttonDown)
    {
        if (buttonDown)
        {
            if (currentHeight < MAX_HEIGHT)
            {
                return VERTICAL_SPEED;
            } else
            {
                return Vector3.zero;
            }
        } else
        {
            if (currentHeight > 0.0f)
            {
                return -2*VERTICAL_SPEED;
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
}
