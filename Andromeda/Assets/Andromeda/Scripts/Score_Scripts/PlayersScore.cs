using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScore : MonoBehaviour
{
    public Text ScoreText;                              // reference to the Score UI Text 

    private int score = 0;                            // variable that set the player score to zero 


    void Start()
    {
        score = 0;                                  // setting the player score to zero at the start of the game 
        UpdateScore();                             // updating the player score to bet set at zero 
    }

  
    void Update()
    {
        
    }

    public void AddScore(int newScore)
    {
        score += newScore;                    // taking are score of zero than adding it to the new score 
        UpdateScore();                       // updating the player score with their new score 
        
    }

    public void UpdateScore()
    {
        ScoreText.text = "score" + score;       // updating the player score UI to display their new score

    }
}
