using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;
    SoundLevelManager sounds;


    public int directionInput;

    public float playerVelocity;
    private Vector3 playerPosition;
    private bool newLife = false;
    public float boundaryL;
    public float boundaryR;

    private Text pointsText;
    private Text livesText;

    public AudioClip[] sfx;


    void Start()
    {
        sounds = FindObjectOfType<SoundLevelManager>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.SetArkanoidAsGame();
        playerPosition = gameObject.transform.position;
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives ;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points;
    }

    void NotNew()
    {
        newLife = false;
    }

    void addPoints(int points)
    {
        newLife = false;
        gameManager.points += points;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points;
    }

    void TakeLife()
    {
        gameManager.lives--;
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives;
        newLife = true;
    }

    void RestartGame()
    {
        gameManager.Restart();
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }

    bool CheckPoints()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0) return true;
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && !newLife)
        {
            sounds.PlaySingle(sfx[0]);
        }
    }

    void Update()
    {
        if (gameManager.IsPaused()) return;
        if (CheckPoints())
        {
            sounds.PlaySingle(sfx[2]);
            gameManager.LoadNextLevel();
        }

        if (gameManager.lives == 0)
        {
            sounds.PlaySingle(sfx[1]);
            RestartGame();
        }

        playerPosition.x += directionInput * playerVelocity;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.position = playerPosition;

        if (playerPosition.x < boundaryL)
        {
            playerPosition.x = boundaryL;
        }
        if (playerPosition.x > boundaryR)
        {
            playerPosition.x = boundaryR;
        }
        transform.position = playerPosition;
    }
}