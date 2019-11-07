using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerDataModel : MonoBehaviour {

    [System.Serializable]    // allows us to change the waves of instances of the class inside of unity inspector
    public class Wave       // Custom class for waves 
    {
        public string name;  // allows the system to determine what wave is coming 
        public Transform enemy;  // reference to the location of where the enemy will spawn in 
        public int count;       // stores the amount of waves 
        public float rate;     // rate at which enemies will spawn into the game


    }

    public Wave[] waves;                 // array for number of waves 
    public int nextWave = 0;           // stores the index of the wave that we want to be creating next 

    public Transform[] spawnPoints;


    public float timeBetweenWaves = 5f; // timer that determines how long we must wait to spawn between waves
    public float waveCountDown;
    public float searchCountDown = 1f;
}


