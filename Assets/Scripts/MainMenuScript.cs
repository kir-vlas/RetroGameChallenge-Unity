using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour{

    public int x;

    public void OnButton1Click()
    {
        SceneManager.LoadScene("arkanoid1");
    }

    public void OnButton2Click()
    {
        SceneManager.LoadScene("pacman1");
    }
    void Update()
    {
        
    }
}
