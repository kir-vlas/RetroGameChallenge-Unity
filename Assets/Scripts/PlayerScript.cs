using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;

    public int directionInput;

    public float playerVelocity;
    private Vector3 playerPosition;

    public float boundaryL;
    public float boundaryR;

    private Text pointsText;
    private Text livesText;



    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("4575");
        playerPosition = gameObject.transform.position;
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives ;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points;
    }

    void addPoints(int points)
    {
        gameManager.points += points;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points;
    }

    void TakeLife()
    {
        gameManager.lives--;
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives;
    }

    void RestartGame()
    {
        gameManager.Restart();
        SceneManager.LoadScene("arkanoid"+gameManager.getLevel());
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

    void Update()
    {
        if (CheckPoints())
        {
            gameManager.LoadNextLevel();
            Debug.Log(gameManager.getLevel());
        }
        if (gameManager.lives == 0)
        {
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