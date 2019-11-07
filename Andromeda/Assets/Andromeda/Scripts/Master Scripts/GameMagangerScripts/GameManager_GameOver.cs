using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManager_GameOver : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject pannelGameOverUI;
        public GameObject RestartButtonUI;
        public GameObject MainMneuButtonUI;

      
        private bool gameOver;


         void Start()
        {
            gameOver = false;
        }

        void OnEnable()
        {
            SetinitialReferences();
            gameManagerMaster.GameOverEvent += ToggleGameOver;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleGameOver;
        }

        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

       public void ToggleGameOver()
        {
            if (pannelGameOverUI != null)
            {
                pannelGameOverUI.SetActive(true);
                gameOver = true;
            }

            if(RestartButtonUI != null)
            {
                RestartButtonUI.SetActive(true);
               
            }

            if(MainMneuButtonUI != null)
            {
                MainMneuButtonUI.SetActive(true);
            }
        }


    }
}

    
