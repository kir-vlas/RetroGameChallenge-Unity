using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores {

    
    public static void Record(int highScore)
    {
        int score;
        string playerName;
        int temp;
        string tempName;
        for (int i = 1; i <= 5; i++) 
        {
            if (PlayerPrefs.GetInt("highscorePos" + i) < highScore)     
            {
                temp = PlayerPrefs.GetInt("highscorePos" + i);     
                PlayerPrefs.SetInt("highscorePos" + i, highScore);     
                if (i < 5)                                       
                {
                    int j = i + 1;
                    highScore = PlayerPrefs.GetInt("highscorePos" + j);
                    PlayerPrefs.SetInt("highscorePos" + j, temp);
                }
            }
        }
    }

}
