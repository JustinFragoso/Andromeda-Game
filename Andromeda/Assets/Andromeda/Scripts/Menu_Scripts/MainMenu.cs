using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class MainMenu : MonoBehaviour
    {

         
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);           // This will load the next scene that is in the Que when the player hits the play button 

           
        }

        public void QuitGame()
        {
            Debug.Log("Player has Quit the game");
            Application.Quit();                                                        // Closing the Unity Application out 
        }
    }
}

