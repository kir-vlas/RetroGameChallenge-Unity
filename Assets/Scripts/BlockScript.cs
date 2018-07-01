using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int hitsToKill;
    public int points;
    private int numberOfHits;
    SoundLevelManager sounds;

    public AudioClip sfx;

    // Use this for initialization
    void Start () {
        sounds = GameObject.FindObjectOfType<SoundLevelManager>();
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
                sounds.PlaySingle(sfx);
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

                player.SendMessage("addPoints", points);

                Destroy(this.gameObject);
            }
            else
            {
                sounds.PlaySingle(sfx);
            }
        }
    }
}
