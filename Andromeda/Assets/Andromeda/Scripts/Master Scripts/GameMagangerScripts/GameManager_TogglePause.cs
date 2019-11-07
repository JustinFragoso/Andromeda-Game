using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;                           // reference to the game master script;

        private bool isPause;                                                 // true or false 




         void OnEnable()
        {
            SetInitialRefereneces();                                       // calling the set initial reference method
            gameManagerMaster.MenuToggleEvent += TogglePause;
            gameManagerMaster.InventoryUIToggleEvent += TogglePause;     // If the inventory is open the game will pause
            gameManagerMaster.PauseMenuEvent += TogglePause;
            gameManagerMaster.GoToMenuSceneEvent += TogglePause;
            gameManagerMaster.RestartLevelEvent += TogglePause;
            gameManagerMaster.GameOverEvent += TogglePause;
        }

         void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePause;
            gameManagerMaster.InventoryUIToggleEvent += TogglePause;        // the game will resume if the inventory has been closed 
            gameManagerMaster.PauseMenuEvent -= TogglePause;
            gameManagerMaster.GoToMenuSceneEvent -= TogglePause;
            gameManagerMaster.RestartLevelEvent -= TogglePause;
            gameManagerMaster.GameOverEvent -= TogglePause;
        }


        void SetInitialRefereneces()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();             // getting the game manager componenet
        }


        void TogglePause()
        {
            if (isPause)
            {
                // this is used to effect the scale of time 
                Time.timeScale = 1;                               // the game is running at normal speed
                isPause = false;                                 // the game is not pause 
                
            }
            else
            {
                Time.timeScale = 0;                          // the game is no longer moving all functions and updates are not running anymore
                isPause = true;                             // the game is paused 
            }
        }
    }

}



