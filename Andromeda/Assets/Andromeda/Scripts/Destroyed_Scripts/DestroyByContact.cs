using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class DestroyByContact : MonoBehaviour
    {

        //public GameObject explosion;                                    // reference to the enemy explosion particle effect 
        //public GameObject playerExplosion;                             // reference to the player explosion particle effect 
        public int scoreValue;                                        //  var for the score value 

        private PlayersScore playerScore;                             // reference to the player score script 
      

        private GameManager_Master gameOver;                       // reference to the Game Manager Master script 



        void Start()
        {
            GameObject PlayerScoreObject = GameObject.FindWithTag("Player Score");             //Finding the game object that has the tag player score 
           
            GameObject GameOverObject = GameObject.FindWithTag("Game Manager");

            if (PlayerScoreObject != null)                                                     // if the playerScoreObject  does not equal null then
            {
                playerScore = PlayerScoreObject.GetComponent<PlayersScore>();               // The system will get access to the player score components
            }
            if (playerScore == null)                                                       // if the player score does equal null then
            {
                Debug.Log("Cannot find playerScore script");
            }

          

            if(GameOverObject != null)
            {
                gameOver = GameOverObject.GetComponent<GameManager_Master>();          // Gettting the Game Manager game Objects components 
            }           
        }





        // Removing Game Object from the Game Scene 
        void OnTriggerEnter(Collider other)
        {
            // Looking for an game object with the tag Boundary or a game object with the tag enemy 
            if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            {
                return;
            }

            // Looking for an object that has the player tag
            if (other.tag == "Player")
            {

                Destroy(other.gameObject);              // Destorying the player 
         
                gameOver.CallGameOver();               // calling the game over event from the game manager master script 

            }
         
            

            // Looking for an object with the shield tag 
            if (other.tag == "Shield")
            {
                other.gameObject.SetActive(false);                  /* if the shield collides with an enemy or their bullets the player shield 
                                                                will be disable*/
            }

            if (other.tag == "Holo")
            {
                other.gameObject.SetActive(false);                  /* if the shield collides with an enemy or their bullets the player shield 
                                                                will be disable*/
            }

            playerScore.AddScore(scoreValue);                          /* adding the amount of points an enemy is worth for defeating  
                                                                   to the player score */


           
            Destroy(gameObject);                                          // Destorying the enemy game object
        }
    }

}

