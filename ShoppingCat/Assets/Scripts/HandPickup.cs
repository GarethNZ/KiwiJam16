using UnityEngine;

public class HandPickup : MonoBehaviour {

    private ItemMeter itemMeter;
	// Use this for initialization
	void Start () {
        itemMeter = FindObjectOfType<ItemMeter>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PickUp"))
        {
            Debug.Log("OnTriggerEnter " + other.gameObject.tag);

            Destroy(other.gameObject);
            itemMeter.itemCollected();
        }
    }
}
