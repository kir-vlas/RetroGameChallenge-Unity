using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreScreenScript : MonoBehaviour {

    private GameObject[] labels;

	void Start () {
        MainMenuMusic music = GameObject.FindObjectOfType<MainMenuMusic>();
        labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
        int i = 0;
        List<int> scores = new List<int>();
        for (int j = 1; j <= 5; j++)
        {
            scores.Add(PlayerPrefs.GetInt("highscorePos" + j));
        }
        var sortedList = labels.OrderBy(go => go.name).ToList();
        var descendingOrder = scores.OrderByDescending(p => p);
        foreach (GameObject label in sortedList)
        {
            label.GetComponent<Text>().text = scores[i].ToString();
            i++;
        }
	}
	
	public void ResetScores()
    {
        for (int i = 1; i <= 5; i++)
        {
            labels[i - 1].GetComponent<Text>().text = "0";
            PlayerPrefs.DeleteKey("highscorePos" + i);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
