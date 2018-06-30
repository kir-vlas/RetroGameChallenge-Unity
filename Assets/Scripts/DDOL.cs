using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {
    public int level;
    public int points;
    public int lives;
    public bool change;
    public bool gameLoaded;

    private static DDOL instance;

    private DDOL()
    {
        level = 1;

    }
	
	void Awake () {
        instance = new DDOL();
        DontDestroyOnLoad(transform.gameObject);
    }
	
   
    public static DDOL GetInstance()
    {
        if (instance == null) instance = new DDOL();
        return instance;
    }

   
}
