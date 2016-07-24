using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour {

    public Canvas ingameCanvas;
    public Canvas gameStateCanvas;
    public Image winImage;
    public Image loseImage;

    public GameObject player;

    private bool ImActive = false;

	// Update is called once per frame
	void Update () {
        if (ImActive && Input.GetButton("Fire1"))
        {
            // Return to splash
            SceneManager.LoadScene("intro");
        }

    }

    private void prepareGameStateCanvas()
    {
        ImActive = true;
        ingameCanvas.enabled = false;
        gameStateCanvas.enabled = true;
        //player.transform.Translate(0, -100f, 0);
    }

    public void gameFail()
    {
        prepareGameStateCanvas();
        loseImage.enabled = true;
    }

    public void gameWin()
    {
        prepareGameStateCanvas();
        winImage.enabled = true;
    }
}
