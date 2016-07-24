using UnityEngine;

public class ItemMeter : MonoBehaviour {

    private int itemsCollected = 0;
    private int REQUIRED_ITEMS = 25;

    private AudioSource itemAudio;

    // Use this for initialization
    void Start () {
        itemAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float xScale = ((float)itemsCollected / (float)REQUIRED_ITEMS) * 100f;

        Vector3 newScale = transform.localScale;
        newScale.x = xScale < 100 ? xScale : 100;
        transform.localScale = newScale;
    }

    public void itemCollected()
    {
        itemsCollected++;
        itemAudio.Play();
    }

    public bool hasRequiredItems()
    {
        return itemsCollected > REQUIRED_ITEMS;
    }
}
