using UnityEngine;

public class ItemMeter : MonoBehaviour {

    private int itemsCollected = 0;
    private int TOTAL_ITEMS = 115;

    private AudioSource itemAudio;

    // Use this for initialization
    void Start () {
        itemAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float xScale = itemsCollected / TOTAL_ITEMS * 100;

        Vector3 newScale = transform.localScale;
        newScale.x = itemsCollected;
        transform.localScale = newScale;
    }

    public void itemCollected()
    {
        itemsCollected++;
        itemAudio.Play();
    }
}
