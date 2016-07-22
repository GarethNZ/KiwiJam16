using UnityEngine;
using System.Collections;

public class FeetController : MonoBehaviour {

    private GameObject leftFoot;
    private GameObject rightFoot;

    private const float MAX_SPEED = 5.0f;
    private Vector3 MOVE_FORWARD = new Vector3(0, 0, MAX_SPEED);


    // TODO: Use
    private const float MAX_STRIDE = 10.0f;

    private Vector3 VERTICAL_SPEED = new Vector3(0, 2.0f, 0);
    private const float MAX_HEIGHT = 5.0f;

	// Use this for initialization
	void Start () {
        rightFoot = transform.Find("Right").gameObject;
        leftFoot = transform.Find("Left").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        updateFoot(rightFoot, "Fire1");
        updateFoot(leftFoot, "Fire2");   
    }

    private void updateFoot(GameObject foot, string input)
    {
        Vector3 movement = Vector3.zero;
        bool inputPressed = Input.GetButton(input);
        if (inputPressed)
        {
            movement += MOVE_FORWARD;
        }
        movement += getVerticalSpeed(foot.transform.position.y, inputPressed);

        foot.transform.Translate(movement * Time.deltaTime);
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
                return -VERTICAL_SPEED;
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
}
