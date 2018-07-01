using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour{

    public int x;
    private MainMenuMusic music;
    private bool keyPressed = false;

    public void Awake()
    {
        GameObject.Find("SoundSwitch").GetComponent<Image>().enabled = AudioListener.volume == 0 ? false : true;
        keyPressed = AudioListener.volume == 0 ? true : false;
        music = GameObject.FindObjectOfType<MainMenuMusic>();
        music.source = AudioSource.FindObjectOfType<AudioSource>();
        music.source.enabled = true;
        music.Play();
    }

    public void OnButton1Click()
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        music.Stop();
        SceneManager.LoadScene("arkanoid1");
    }

    public void OnButton2Click()
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        
        SceneManager.LoadScene("pacman1");
    }

    public void OnButton3Click()
    {
        SceneManager.LoadScene("_highscore");
        //GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }

    public void SwitchSound()
    {
        if (!keyPressed)
        {
            AudioListener.volume = 0;
            GameObject.Find("SoundSwitch").GetComponent<Image>().enabled = false;
            keyPressed = true;
        }
        else
        {
            AudioListener.volume = 1;
            GameObject.Find("SoundSwitch").GetComponent<Image>().enabled = true;
            keyPressed = false;
        }
    }

    public void OnButton4Click()
    {
        Application.Quit();
    }
    
}
