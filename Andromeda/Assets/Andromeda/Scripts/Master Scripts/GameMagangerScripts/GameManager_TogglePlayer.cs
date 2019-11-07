using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManager_TogglePlayer : MonoBehaviour
    {
        public Playercontroller playerController;                                   // var reference to the player controller 
        private GameManager_Master gameManagerMaster;                              // var reference to the game master script 

     

         void OnEnable()
        {
            SetinitialReferences();                                                  // calling the set initial references method 
            gameManagerMaster.MenuToggleEvent += TogglePlayerController;             
            gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
        }

         void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
        }


        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }


        void TogglePlayerController()
        {
            if(playerController != null)
            {
                playerController.enabled = !playerController.enabled;
            }

          

            
        }
    }
}

