using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public bool levelStart = false;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;

    // Use this for initialization
    void Start () {
        ballInitialForce = new Vector2(100.0f, 300.0f);
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
            ballIsActive = !ballIsActive;
            GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = 0.371f;
            transform.position = ballPosition;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            playerObject.SendMessage("TakeLife");
        }
    }
}
