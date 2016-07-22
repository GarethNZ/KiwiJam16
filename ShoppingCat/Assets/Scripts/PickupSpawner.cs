using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public GameObject[] pickups;
    public GameObject[] targets;

    private float PERIOD = 0.5f;

    private float lastTime = 0;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > (lastTime + PERIOD))
        {
            lastTime += Time.time;
            int pickup = Random.Range(0, pickups.Length);
            int position = Random.Range(0, targets.Length);
            Vector3 spawnPoint = targets[position].transform.position;
            spawnPoint.y = Random.Range(0, 5.0f);
            GameObject newPickup = Instantiate(pickups[pickup], spawnPoint, targets[position].transform.rotation) as GameObject;
            newPickup.transform.SetParent(this.transform);
        }
	}
}
