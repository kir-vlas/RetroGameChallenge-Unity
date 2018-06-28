using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {

    public Vector3 newLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            Rigidbody2D player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            player.isKinematic = true;
            player.transform.position = newLocation;
            player.isKinematic = false;
        }
    }
}
