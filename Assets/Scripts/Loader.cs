using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public DDOL ddolIns;

	
	void Awake () {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        ddolIns = DDOL.GetInstance();
        
    }
	
	
}
