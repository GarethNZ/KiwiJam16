using UnityEngine;
using System.Collections;

public class TorsoTwist : MonoBehaviour {

    private string inputAxis;

    // Both directions (+ & -)
    public float MAX_ROTATION = 90.0f;

    // Use this for initialization
    void Start () {
        // Randomly pick an input, either P1 or P2 triggers
        inputAxis = Random.Range(0f, 1f) < 0.5f ? "Triggers" : "2Triggers";

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(0, MAX_ROTATION * Input.GetAxis(inputAxis), 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation, 0.5f); ;
    }
}
