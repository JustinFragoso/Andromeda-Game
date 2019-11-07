using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{

    // This script toggles the pause menu 
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;                    //  var reference to the game manager master scripts 
        public GameObject Menu;                                          // var reference for the menu UI


     
        void Start()
        {
            //ToggleMenu();                                              // calling the toggle menu method 
        }

       
        void Update()
        {
            CheckForMenuToggleRequest();                                             // calling the check for menu toggle request method 
                                 
        }

         void OnEnable()
        {
            SetinitialReferences();                                             // calling the set initial references method 
            gameManagerMaster.PauseMenuEvent += ToggleMenu;                     // enabling the toggle menu if the player dies or the game is over
        }

        void OnDisable()
        {
            gameManagerMaster.PauseMenuEvent -= ToggleMenu;                  // disabling the toggle menu if the player is alive 
        }

        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();             // getting the master script compoments 
        }

        void CheckForMenuToggleRequest()
        {
            // Mechanic that will allow the player to exit the game by pressing down on the esc key 
            if(Input.GetKeyUp(KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn)
            
            {

                //ToggleMenu();                                                   // calling the toggle menu method 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
            }

            // Mechanic that will allow the player to exit the game by pressing down on the P key 
            if (Input.GetKeyUp(KeyCode.P) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn)
              
            {
                ToggleMenu();                                                   // calling the toggle menu method 
            }
        }

        // Making this method public allows you to control toggle menu with button presses 
        public void ToggleMenu()
        {
            if (Menu != null)
            {
                Menu.SetActive(!Menu.activeSelf);                               //actvating the menu gameobject if it is disable
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;       // toggling the menu on and off 
                gameManagerMaster.CallEventMenuToggle();                        // calling the menu toggle event from the game master script 
               
            }   
            else
            {
               
                Debug.LogWarning("You need to assign a UI GameObject to the Toggle UI Script in the inspector");
            }    
            
        }


       
    }


}



