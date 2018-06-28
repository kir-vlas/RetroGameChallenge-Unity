using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
    public Transform[] waypoints;
    int cur = 0;
    public float speed;
    public string fruitType;
    private Vector3 fruitPosition;
    public float timeLeft;
    private bool motion = false;

	void Start () {
        fruitPosition = transform.position;
        transform.position = new Vector3(100,100);
	}
	
	void FixedUpdate () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && !motion)
        {
            transform.position = fruitPosition;
            motion = true;
        }
        if (motion)
        {
            if (transform.position != waypoints[cur].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position,
                                                waypoints[cur].position,
                                                speed);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            else cur = (cur + 1) % waypoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("addFruit",fruitType);
            Destroy(gameObject);
        }
    }
}
