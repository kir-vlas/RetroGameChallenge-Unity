using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int hitsToKill;
    public int points;
    private int numberOfHits;

    // Use this for initialization
    void Start () {
        numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;

            if (numberOfHits == hitsToKill)
            {
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

                player.SendMessage("addPoints", points);

                Destroy(this.gameObject);
            }
        }
    }
}
