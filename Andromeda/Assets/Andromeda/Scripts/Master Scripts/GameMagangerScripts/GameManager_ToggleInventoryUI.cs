using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {

        [Tooltip("Does this game mode have an invetory? Set to true if that is the case")]
        public bool hasInventory;                                   // true or false var to determine if there is an inventory 
        public GameObject inventoryUI;                             // var for the inventory gameObject 
        public string toggleInventoryButton;                      // var for the inventory button name 

        private GameManager_Master gameManagerMaster;           // var to the game manager master script 





        // Start is called before the first frame update
        void Start()
        {
            SetinitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInventoryUIToggleRequest();
        }


        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if(toggleInventoryButton == "")
            {
                Debug.LogWarning("Please type in the name of the button used to toggle the inventory in" +
                    " GameManager_ToggleInventoryUI");
                this.enabled = false;                          // anything in the update method won't be running 
            }
        }


        void CheckForInventoryUIToggleRequest()
        {
            if(Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && 
                !gameManagerMaster.isGameOver && hasInventory)
            {
                ToggleInventoryUI();                                        // Calling the inventory method 
            }
        }

        void ToggleInventoryUI()
        {
            if(inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallEventInventoryUIToggle();
            }
        }
    }

}

