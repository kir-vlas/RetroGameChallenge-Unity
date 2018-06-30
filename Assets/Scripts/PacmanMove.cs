using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanMove : MonoBehaviour {

    public float speed;
    Vector2 dest = Vector2.zero;
    private GameManager gameManager;
    private Vector3 playerPosition;
    private int directionInput;
    private Text pointsText;
    private Text livesText;
    private bool levelLoading;
    void Start()
    {
        levelLoading = false;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.SetPacmanAsGame();
        playerPosition = transform.position;
        dest = transform.position;
        addUnlockedFruits(gameManager.getFruitCounter());
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points; 
    }

    bool checkDots()
    {
        GameObject[] dots= GameObject.FindGameObjectsWithTag("Dot");
        if (dots.Length == 0) return true;
        return false;
    }
    void addPoints(int points)
    {
        gameManager.points += points;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + gameManager.points;
    }

    void addFruit(string fruitType)
    {
        Image fruitImage = GameObject.Find(fruitType + "Image").GetComponent<Image>();
        fruitImage.enabled = true;
        gameManager.addFruit();
    }

    void addUnlockedFruits(int unlocked)
    {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("FruitImage");
        for (int i = 0; i < unlocked; i++){
            fruits[fruits.Length-i-1].GetComponent<Image>().enabled = true;
        }
    }

    void TakeLife()
    {
        gameManager.lives--;
        pointsText = GameObject.Find("LivesText").GetComponent<Text>();
        pointsText.text = "Lives: " + gameManager.lives;
        transform.position = playerPosition;
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject ghost in ghosts)
        {
            ghost.SendMessage("ReturnGhost");
        }
    }


    void RestartGame()
    {
        gameManager.Restart();
        SceneManager.LoadScene("pacman" + gameManager.getLevel());
    }

    public void Move(int button)
    {
        directionInput = button;
    }

    void LoadLevel()
    {
        if (!levelLoading)
        {
            levelLoading = true;
            gameManager.LoadNextLevel();
        }
    }
    void FixedUpdate()
    {
        if (gameManager.IsPaused()) return;
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        if (checkDots())
            LoadLevel();
        if (false)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
                dest = (Vector2)transform.position + Vector2.down;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
                dest = (Vector2)transform.position + Vector2.left;
        }
        if (true)
        {
            if (directionInput == 1 && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (directionInput == 2 && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (directionInput == 3 && valid(Vector2.down))
                dest = (Vector2)transform.position + Vector2.down;
            if (directionInput == 4 && valid(Vector2.left))
                dest = (Vector2)transform.position + Vector2.left;
        }
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
