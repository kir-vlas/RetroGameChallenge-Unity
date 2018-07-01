using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterBlock : MonoBehaviour {

    SoundLevelManager sounds;
    public AudioClip clip;

    private void Start()
    {
        sounds = FindObjectOfType<SoundLevelManager>();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            
            sounds.PlaySingle(clip);
            GameObject.FindObjectOfType<GameManager>().AddEasterBlock();
            Debug.Log("Secret block has been removed.");
            Destroy(this.gameObject);
        }
    }
}
