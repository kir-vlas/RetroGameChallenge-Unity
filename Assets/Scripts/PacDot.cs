using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour {

    public int points;
    public AudioClip sfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            SoundLevelManager sounds = GameObject.FindObjectOfType<SoundLevelManager>();
            sounds.PlaySingle(sfx);
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("addPoints", points);
            Destroy(gameObject);
        }
    }
}
