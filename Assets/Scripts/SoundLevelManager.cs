using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevelManager : MonoBehaviour {

    public AudioSource efxSource;                               
    public static SoundLevelManager instance = null;        


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }


   
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

}
