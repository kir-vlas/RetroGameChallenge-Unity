using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
            Destroy(gameObject);
    }
}
