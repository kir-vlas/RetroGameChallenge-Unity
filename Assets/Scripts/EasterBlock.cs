using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterBlock : MonoBehaviour {


    private void Start()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            GameObject.FindObjectOfType<GameManager>().AddEasterBlock();
            Debug.Log("Secret block has been removed.");
            Destroy(this.gameObject);
        }
    }
}
