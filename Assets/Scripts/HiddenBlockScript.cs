using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBlockScript : MonoBehaviour {

    public int points;
    public GameObject[] neirbours;

	void Start () {
        GetComponent<SpriteRenderer>().enabled = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("addPoints", points);
            foreach(GameObject neirBlock in neirbours)
            {
                if (neirBlock != null) neirBlock.GetComponent<SpriteRenderer>().enabled = true;
            }
            Destroy(this.gameObject);
        }
    }

}
