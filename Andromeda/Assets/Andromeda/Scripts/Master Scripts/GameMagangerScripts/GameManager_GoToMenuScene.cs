using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;


        void OnEnable()
        {
            SetinitialReferences();
            gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
        }


        void OnDisable()
        {
            gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
        }


        void SetinitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }



        void GoToMenuScene()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
        }
    }


}




