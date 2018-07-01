using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour {

    public AudioClip sound;
    public AudioSource source;
    private static MainMenuMusic instance = null;
    private bool isPlaying = false;
    public static MainMenuMusic Instance { get { return instance; }  }

    void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        source = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        DontDestroyOnLoad(source);
    }
	
    public void Play()
    {
        if (isPlaying) return;
        source.Play();
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
        source.Stop();
    }
}
