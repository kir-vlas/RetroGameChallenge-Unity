using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour {

    public int points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("addPoints", points);
            Destroy(gameObject);
        }
    }
}
