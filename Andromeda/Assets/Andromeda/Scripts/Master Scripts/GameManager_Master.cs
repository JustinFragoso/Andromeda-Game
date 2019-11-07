using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The way this system works is instead of the scripts talking to each other 
 * they talk to the master script and then on master script an event gets called 
 * and then stuff happens cross the other scripts. Each script just looks at the 
 * master script for finding important information*/

namespace S3 {


    public class GameManager_Master : MonoBehaviour
    {

        public delegate void GameManagerEvenHandler();
        public event GameManagerEvenHandler MenuToggleEvent;
        public event GameManagerEvenHandler InventoryUIToggleEvent;
        public event GameManagerEvenHandler RestartLevelEvent;
        public event GameManagerEvenHandler GoToMenuSceneEvent;
        public event GameManagerEvenHandler GameOverEvent;
        public event GameManagerEvenHandler PauseMenuEvent;


        public bool isGameOver;
        public bool isInventoryUIOn;
        public bool isMenuOn;
       



        public void CallEventMenuToggle()
        {
            if(MenuToggleEvent != null)
            {
                MenuToggleEvent();
            }
        }

        public void CallEventInventoryUIToggle()
        {
            if(InventoryUIToggleEvent != null)
            {
                InventoryUIToggleEvent();
            }
        }


        public void CallEventIRestartLevel()
        {
            if (RestartLevelEvent != null)
            {
                RestartLevelEvent();
            }
        }


        public void CallEventGoToMenuScreen()
        {
            if (GoToMenuSceneEvent != null)
            {
                GoToMenuSceneEvent();
            }
        }


        public void CallGameOver()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }

        public void CallPauseMenu()
        {
            if(PauseMenuEvent != null)
            {
                PauseMenuEvent();
            }
        }
       
    }

}

