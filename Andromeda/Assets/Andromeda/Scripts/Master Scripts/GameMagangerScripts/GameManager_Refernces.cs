using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script keeps some really important 
 * References that a lot of other scripts need
 * to be able to do stuff*/

namespace S3
{
    public class GameManager_Refernces : MonoBehaviour
    {
        public string playerTag;
        public static string _playerTag;

        public string EnemyTag;
        public static string _enemyTag;


        public static GameObject _player;                                   // Golobal var ( you can only have one of them) 


        void OnEnable()
        {
            if(playerTag == "")
            {
                Debug.LogWarning("Please type in the name of the player tag in the GameManager_References in" +
                    " slot in the inspector or else the S3 systems will not work");
            }

            if (EnemyTag == "")
            {
                Debug.LogWarning("Please type in the name of the player tag in the GameManager_References in" +
                    " slot in the inspector or else the S3 systems will not work");
            }

            _playerTag = playerTag;
            _enemyTag = EnemyTag;

            _player = GameObject.FindGameObjectWithTag(_playerTag);


        }
    }


}



