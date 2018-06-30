using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int MAX_LIVES = 5;

    private int currentLevel = 1;
    private string gameType;
    int[] levelCounter = { 5, 3 };
    private int fruitCounter = 0;
    private int currentGame = 0;
    public int points;
    public int lives;
    private int easterBlocks = 0;
    private bool gameIsPaused = false;
    private float timesc;


    public void SetPause()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = timesc;
    }

    public bool IsPaused()
    {
        return gameIsPaused;
    }

    public void AddEasterBlock()
    {
        easterBlocks++;
    }

    public void SetArkanoidAsGame()
    {
        currentGame = 0;
    }

    private bool IsSecretArkanoidLevelAllowed()
    {
        if (easterBlocks == 5) return true;
        return false;
    }

    public void SetPacmanAsGame()
    {
        currentGame = 1;
    }

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
        timesc = Time.timeScale;
        Debug.Log("gm");
        DontDestroyOnLoad(transform.gameObject);
        InitGame();
    }

    public void ResetGame()
    {
        points = 0;
        currentLevel = 1;
        lives = MAX_LIVES;
    }

    public void Restart()
    {
        RecordScore();
        points = 0;
        lives = MAX_LIVES;
        SceneManager.LoadScene(0);
    }

    private void RecordScore()
    {
        HighScores.Record(points);
    }

    public void LoadNextLevel ()
    {
        if (levelCounter[currentGame] == currentLevel && fruitCounter !=3 && easterBlocks != 5)
        {
            currentLevel = 1;
            points = 0;
            lives = MAX_LIVES;
            RecordScore();
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
        if (IsSecretArkanoidLevelAllowed())
        {
            easterBlocks = 0;
        }
        if (SceneManager.GetActiveScene().name == "arkanoid6")
        {
            SceneManager.LoadScene("pacman1");
            return;
        }
        else SceneManager.LoadScene(gameType + currentLevel);
    }

    void InitGame ()
    {
        Debug.Log("gm");
        DDOL dd = DDOL.GetInstance();
        gameType = "arkanoid";
        currentLevel = dd.level;
        points = dd.points;
        lives = MAX_LIVES;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
