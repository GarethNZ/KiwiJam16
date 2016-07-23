using UnityEngine;

public class HandPickup : MonoBehaviour {

    private ScoreController scoreController;
	// Use this for initialization
	void Start () {
        scoreController = FindObjectOfType<ScoreController>();
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.tag);
        if (other.gameObject.tag.Equals("PickUp"))
        {
            Destroy(other.gameObject);
            scoreController.increment();
        }
    }
}
