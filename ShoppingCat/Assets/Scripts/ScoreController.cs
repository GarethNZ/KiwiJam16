using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int score = 0;
    private Text textDisplay;
	// Use this for initialization
	void Start () {
        textDisplay = GetComponent<Text>();
    }
	
    public void increment()
    {
        score++;
        textDisplay.text = ""+score;
    }
}
