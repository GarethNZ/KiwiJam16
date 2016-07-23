using UnityEngine;
using System.Collections;

public class CameraZAxisOnly : MonoBehaviour {

    public Transform zValueSource;
    public float zOffset = 18f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.z = zValueSource.position.z + zOffset;
        transform.position = newPos;
	}
}
