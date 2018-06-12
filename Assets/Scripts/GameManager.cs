using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int level = 1;
    private string gameType;
    private List<int> LevelScores = new List<int>(new int[] { 270, 720, 1260, 2070, 2800 });

    public int points;
    public int lives;

    public int getLevel()
    {
        return level;
    }

    public void SetOnNextLevel()
    {
        DDOL dd = DDOL.GetInstance();
        dd.change = false;
        points = dd.points;
        level = dd.level;
        lives = dd.lives;
    }

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(transform.gameObject);
        InitGame();
    }

    public void ResetGame()
    {
        points = 0;
        level = 1;
        lives = 100;
    }

    public void Restart()
    {
        points = 0;
        lives = 100;
        SceneManager.LoadScene(gameType+level);
    }

    public bool CheckPoints()
    {
        Debug.Log(points + "  " + level + " " + LevelScores[level - 1]);
        if (points >= LevelScores[level - 1]) { return true; }
        return false;
    }

    public void LoadNextLevel ()
    {
        level++;
        if (LevelScores.Count == level)
        {
            level = 1;
            points = 0;
            lives = 100;
            SceneManager.LoadScene(0);
        }
        Debug.Log(level);
        DDOL dd = DDOL.GetInstance();
        dd.level = level;
        dd.lives = lives;
        dd.points = points;
        dd.change = true;
        SceneManager.LoadScene(gameType+level);
    }

    void InitGame ()
    {
        DDOL dd = DDOL.GetInstance();
        gameType = "arkanoid";
        level = dd.level;
        points = dd.points;
        lives = dd.lives;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
