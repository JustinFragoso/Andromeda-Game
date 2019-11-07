using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{

    public class GameManager_ToggleCursor : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;                              // var reference to the game master script 
        private bool isCursorLocked = true;

        void OnEnable()
        {
            SetinitialReferences();
            gameManagerMaster.MenuToggleEvent += ToggleCursorState;
            gameManagerMaster.InventoryUIToggleEvent += ToggleCursorState;

        }


        void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= ToggleCursorState;
            gameManagerMaster.InventoryUIToggleEvent -= ToggleCursorState;
        }


        void Update()
        {
            CheckIfCursorShouldBeLocked();

        }


        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }


        void ToggleCursorState()
        {
            isCursorLocked = !isCursorLocked;
        }


        void CheckIfCursorShouldBeLocked()
        {
            if (isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;                                     // hiddes the cursor 
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;                                    // cursor is visiable
            }
        }
    }

}



