using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour {

    GameManager gameManager;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	public void ReturnToMenu()
    {
        gameManager.ResetGame();
        SceneManager.LoadScene(0);
    }
}
