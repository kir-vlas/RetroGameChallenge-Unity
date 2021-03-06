﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public bool levelStart = false;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;
    public AudioClip sfx;
    SoundLevelManager sounds;

    public bool IsActive()
    {
        return ballIsActive;
    }

    // Use this for initialization
    void Start () {
        sounds = GameObject.FindObjectOfType<SoundLevelManager>();
        ballInitialForce = new Vector2(80.0f, 240.0f);
        ballIsActive = false;
        ballPosition = transform.position;
    }

    public void Jump(bool check)
    {
        levelStart = check;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelStart)
        {
            if (!ballIsActive)
            {
                GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
                ballIsActive = !ballIsActive;
            }

        }

        if (!ballIsActive && playerObject != null)
        {
            ballPosition.x = playerObject.transform.position.x;
            transform.position = ballPosition;
        }

        if (ballIsActive && transform.position.y < -0.2f)
        {
            sounds.PlaySingle(sfx);
            ballIsActive = !ballIsActive;
            GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = 0.385f;
            transform.position = ballPosition;           
            playerObject.SendMessage("TakeLife");
        }
    }
}
