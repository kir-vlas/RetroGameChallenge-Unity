using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour {

    GameManager gameManager;
    private bool paused = false;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PauseGame()
    {
        if (!paused)
        {
            GameObject text = GameObject.FindGameObjectWithTag("Pause");
            text.GetComponent<Text>().enabled = true;
            paused = !paused;
            gameManager.SetPause();
        }
        else
        {
            GameObject text = GameObject.FindGameObjectWithTag("Pause");
            text.GetComponent<Text>().enabled = false;
            paused = !paused;
            gameManager.ResumeGame();
        }
    }

	public void ReturnToMenu()
    {
        if (paused)
            gameManager.ResumeGame();
        gameManager.ResetGame();
        SceneManager.LoadScene(0);
    }
}
