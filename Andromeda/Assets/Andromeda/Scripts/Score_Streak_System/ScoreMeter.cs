using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMeter : MonoBehaviour
{
    [SerializeField]
    private Image PowerGauge;                                    // Getting an instance to the power meter gauge UI

    [SerializeField]
    private Text ScoreText;                                    // Getting instance to the score text UI

 

    [SerializeField]
    private float score = 0;                                 // float Variable that will set the score to 0 
    [SerializeField]
    private float maxScore = 100;                           // float variable that will keep maxscore at a constent value of 100 

    private float scoreIncreasing = 0.0f;                 // float variable that will determine how much the player score will increase 

    public GameObject scorestreak;

    private AudioSource audioSource;                     // Var that contains information for the aduiosoucre compoment 

    AudioSource Scorestreakmeter;                         // instents that will gaining access to the AudioSource componment 


    void Start()
    {

        score = 0;                                     // at the start of the game the player scorestreak meter will be set to zero 
        UpdateScore();                                // instance that will set the score meter UI to 0 
        audioSource = GetComponent<AudioSource>();              // getting the audio scoure compoment 
        Scorestreakmeter = GetComponent<AudioSource>();        // getting the score streakmeter audio scoure 
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

        // Postive Feedback Loop 
        score += Time.deltaTime;            // the player score will increase every frame 
        score += scoreIncreasing;          // the player score will increase at the rate of 1 
        UpdateScore();

        if (score > 100)                // if the player score is greater than 100 
        {
            score = 100;               // then the player score will stop increasing per frame intill they activate their special ability 
           
        }






        // Activate Spacecraft Special Ability (Mechanic)
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RemoveScore();                      // calling the remove score method 



        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            scorestreak.SetActive(false);
        }

        ScoreMeterFull();

      
        
    }


    // Scoring System                                                 
    public void AddScore(int newScore)
    {


        // Logical Expression 

        score += newScore;
        

        if (score > maxScore)                        // if the player score is greater than 100
        {

            score = maxScore;                     // then the player score will equal 100 

            audioSource.Play();                    // playing the score streakmeter full audio 




            Debug.Log("Played score streakmeter full audio" + audioSource);
        }
        else
        {

            Debug.Log("Did not Play score streakmeter full audio" + audioSource);
        }

        UpdateScore();                           // Updating the ScoreMeter UI 
     





    }




    public void UpdateScore()
    {
        if(score != maxScore)
        {
            float ratio = score / maxScore;
            PowerGauge.rectTransform.localScale = new Vector3(ratio, 1, 1);

            ScoreText.text = (ratio * 100).ToString("0") + "%";
            ScoreText.color = Color.white;

        }
        ScoreMeterFull();                                                        // calling the score meter full method when score = 100 


       
    }


    public void ScoreMeterFull()
    {
        if (score == maxScore)
        {
            ScoreText.text = "Scorestreak Meter Full";                      // changing the score meter precentage text to say score meter full at 100% 
            ScoreText.color = Color.white;                                   // changing the color of the score meter text when the score meter is full 

        }


    }

   



    // Method that will remove the score at 100 only if the player presses down on the Right Mouse Button 

    public void RemoveScore()
    {
        if (score == maxScore)                      // if the score is equal to max score which is 100 then we are going to 
        {


            score -= maxScore;                    //  subtract are score from the max score which will give us 0 

            UpdateScore();                      // score will be set back to zero 
           
            scorestreak.SetActive(true);




            Debug.Log("Score was reset:" + score);
        }
        else
        {
            Debug.Log("you're not at max score " + maxScore);
        }
    }

}


   

   




