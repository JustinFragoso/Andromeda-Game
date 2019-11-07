using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;


        void OnEnable()
        {
            SetInitialRefereneces();
            gameManagerMaster.RestartLevelEvent += RestartLevel;
        }


        void OnDisable()
        {
            gameManagerMaster.RestartLevelEvent -= RestartLevel;
        }


        void SetInitialRefereneces()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();             // getting the game manager componenet
        }


       void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }


}
