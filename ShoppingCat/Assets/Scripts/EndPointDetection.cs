using UnityEngine;
using System.Collections;

public class EndPointDetection : MonoBehaviour {

    private GameStateController gameController;
    private ItemMeter itemMeter;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameStateController>();
        itemMeter = GameObject.FindObjectOfType<ItemMeter>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("EndPoint"))
        {
            Debug.Log("OnTriggerEnter " + other.gameObject.name);

            if (itemMeter.hasRequiredItems())
            {
                gameController.gameWin();
            }


        }
    }
}
