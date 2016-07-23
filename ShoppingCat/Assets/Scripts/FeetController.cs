﻿using UnityEngine;
using System.Collections;

public class FeetController : MonoBehaviour {

    public delegate void SteppedTooFar();
    public static event SteppedTooFar onOverStride;

    public GameObject upperBody;
    public GameObject leftFoot;
    public GameObject rightFoot;

    private const float MAX_SPEED = 5.0f;
    //private Vector3 MOVE_FORWARD = new Vector3(0, 0, MAX_SPEED);

    private const float MAX_STRIDE = 10.0f;

    //private Vector3 VERTICAL_SPEED = new Vector3(0, 2.0f, 0);
    private const float MAX_HEIGHT = 5.0f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        updateFoot(rightFoot, "2Horizontal", "2Vertical");
        updateFoot(leftFoot, "2Horizontal_b", "2Vertical_b");

        Vector3 upperBodyTarget = upperBody.transform.position;
        upperBodyTarget.z = (rightFoot.transform.position.z + leftFoot.transform.position.z) / 2;
        upperBodyTarget.x = (rightFoot.transform.position.x + leftFoot.transform.position.x) / 2;
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
    private void updateFoot(GameObject foot, string leftRightAxis, string forwardBackAxis)
    {
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis(leftRightAxis);
        movement.z = Input.GetAxis(forwardBackAxis);
        foot.transform.Translate(movement * MAX_SPEED * Time.deltaTime);
    }
}
