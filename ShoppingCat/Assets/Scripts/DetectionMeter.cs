using UnityEngine;
using System.Collections.Generic;

class DetectionMeter : MonoBehaviour
{
    private float totalDetection = 0f;
    // Use this for initialization
    void Start()
    {

    }


    private float STANDARD_DETECTION_RATE = 1.0f;
    private float OBSTACLE_DETECTION_RATE = 3.0f;

    private bool isObstacle = false;
     
    // Update is called once per frame
    void Update()
    {
        totalDetection += (isObstacle ? OBSTACLE_DETECTION_RATE : STANDARD_DETECTION_RATE) * Time.deltaTime;
        if (totalDetection > 100)
        {
            // TODO: Game fail
        }
        Vector3 newScale = transform.localScale;
        newScale.x = totalDetection;
        transform.localScale = newScale;
    }

    // TODO: Use a sets
    private List<GameObject> objectsIntersectingWithObstacles = new List<GameObject>();

    public void intersectingWithObstacle(GameObject limb)
    {
        if (!objectsIntersectingWithObstacles.Contains(limb))
        {
            objectsIntersectingWithObstacles.Add(limb);
        }
        isObstacle = true;
    }

    public void nolongerIntersectingWithObstacle(GameObject limb)
    {
        objectsIntersectingWithObstacles.Remove(limb);
        if (objectsIntersectingWithObstacles.Count == 0) {
            isObstacle = false;
        }
    }
}
