using UnityEngine;

public class HandPickup : MonoBehaviour {

    private ScoreController scoreController;
	// Use this for initialization
	void Start () {
        scoreController = FindObjectOfType<ScoreController>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PickUp"))
        {
            Debug.Log("OnTriggerEnter " + other.gameObject.tag);

            Destroy(other.gameObject);
            scoreController.increment();
        }
    }
}
