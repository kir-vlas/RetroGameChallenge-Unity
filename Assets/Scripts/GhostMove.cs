using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {
    public Transform[] waypoints;
    int cur = 0;
    public float speed;
    public GameObject playerObject;
    private GameManager gameManager;
    private Vector3 ghostPosition;

    private void Start()
    {
        ghostPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }


    void FixedUpdate ()
    {
        if (gameManager.IsPaused()) return;
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
        
    }

    void ReturnGhost()
    {
        cur = 0;
        transform.position = ghostPosition;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            playerObject.SendMessage("TakeLife");
        }
    }
}

