using UnityEngine;
using System.Collections;

public class CollidableLimb : MonoBehaviour {

    private DetectionMeter detectionMeter;
    // Use this for initialization
    void Start()
    {
        detectionMeter = FindObjectOfType<DetectionMeter>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            Debug.Log("CollidableLimb " + gameObject.name + " OnTriggerEnter " + other.gameObject.tag);
            detectionMeter.intersectingWithObstacle(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            Debug.Log("CollidableLimb " + gameObject.name + " OnTriggerExit " + other.gameObject.tag);
            detectionMeter.nolongerIntersectingWithObstacle(gameObject);
        }
    }
}
