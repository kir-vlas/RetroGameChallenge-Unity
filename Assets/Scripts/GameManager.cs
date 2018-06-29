using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int currentLevel = 1;
    private string gameType;
    int[] levelCounter = { 5, 3 };
    private int fruitCounter = 0;
    private int currentGame = 1;
    public int points;
    public int lives;

    public void setGame(string game)
    {
        gameType = game;
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void addFruit()
    {
        fruitCounter++;
    }

    public int getFruitCounter()
    {
        return fruitCounter;
    }

    public void SetOnNextLevel()
    {
        DDOL dd = DDOL.GetInstance();
        dd.change = false;
        points = dd.points;
        currentLevel = dd.level;
        lives = dd.lives;
    }

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
        Debug.Log("gm");
        DontDestroyOnLoad(transform.gameObject);
        InitGame();
    }

    public void ResetGame()
    {
        points = 0;
        currentLevel = 1;
        lives = 100;
    }

    public void Restart()
    {
        points = 0;
        lives = 100;
        SceneManager.LoadScene(gameType+currentLevel);
    }


    public void LoadNextLevel ()
    {
        if (levelCounter[currentGame] == currentLevel && fruitCounter !=3)
        {
            currentLevel = 1;
            points = 0;
            lives = 100;
            SceneManager.LoadScene(0);
            return;
        }
        currentLevel++;
        Debug.Log(currentLevel);
        DDOL dd = DDOL.GetInstance();
        dd.level = currentLevel;
        dd.lives = lives;
        dd.points = points;
        dd.change = true;
        if (fruitCounter == 3) SceneManager.LoadScene("pacman4");
        else SceneManager.LoadScene(gameType+currentLevel);
    }

    void InitGame ()
    {
        Debug.Log("gm");
        DDOL dd = DDOL.GetInstance();
        gameType = "arkanoid";
        currentLevel = dd.level;
        points = dd.points;
        lives = dd.lives;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
