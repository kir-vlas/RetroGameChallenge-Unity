using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour{

    public int x;
    private bool showHighScore = false;

    public void OnButton1Click()
    {
        SceneManager.LoadScene("arkanoid1");
    }

    public void OnButton2Click()
    {
        SceneManager.LoadScene("pacman1");
    }

    public void OnButton3Click()
    {
        showHighScore = true;
    }

    public void OnButton4Click()
    {
        Application.Quit();
    }
    void OnGUI()
    {
        if (showHighScore)
        {
            for (int i = 1; i <= 5; i++)
            {
                GUI.Box(new Rect(100, 75 * i, 150, 50), "Pos " + i + ". " + PlayerPrefs.GetInt("highscorePos" + i).ToString());
            }
            
        }
    }
}
