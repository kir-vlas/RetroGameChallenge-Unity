using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour {

    public AudioClip sfx;
    SoundLevelManager sounds;
	void Start () {
        sounds = GameObject.FindObjectOfType<SoundLevelManager>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            sounds.PlaySingle(sfx);
        }
    }
}
