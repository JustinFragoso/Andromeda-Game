using System.Collections;
using UnityEngine;


public class WaveSpawner : SpawnerDataModel
{
    public enum SpawnState { Spawning, Waiting, Counting}       // Each of the different states that can be found within the state machine 

    private SpawnState state = SpawnState.Counting;           // the state machine will always start in the Counting state 

    public GameController gameController;                  // private reference to the game controller script

   


    void Start()
    {
        if (spawnPoints.Length == 0)                     // if statement that will determine if there are any spawnpoints located with in the inspector
        {
            Debug.LogError("No spawn point reference"); // if there is no spawn points then debug the system 
        }
        waveCountDown = timeBetweenWaves;             // if there are spawn points then are wave count down will be equal to the time between waves 
    }


    void Update()
    {
        if(state == SpawnState.Waiting)           // an if then statement that will deteremine if are state machine is set to the waiting state 
        {
            if (!EnemyIsAlve())                 // an if then state that will determine if enemies are not alive  
            {
                WaveCompleted();              // if there are no enemies alive then the wave is completed
            }
            else
            {
                return;                     // if there are enemies alive then the system will return the statement and proccessed to run the rest of the code 
            }
        }
       
        if (waveCountDown <= 0)          // an if statement that will determine if are wave count down is less then 0 
        {
            if(state != SpawnState.Spawning)       // if the state mechaine is not equal to the spawning state then we will 
            {
                StartCoroutine(SpawnWave(waves[nextWave]));             // start spawning in the next set of waves 
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;                        // we will be counting down the time that it takes to spawn a wave 
        }
    }


    // Wave Complete system 
    void WaveCompleted()
    {
       
        Debug.Log("Wave Completed!");
        
        state = SpawnState.Waiting;                                // the state mechaninc is set to the Counting state 
        waveCountDown = timeBetweenWaves;                          // and wave count down is equal to 5 

        if (nextWave + 1 > waves.Length - 1)                      // if the next wave is these than the wave length - 1 then
        {
            nextWave = 0;                                      // the next wave will be = to 0 then 

            Debug.Log("All waves complete! Looping...");      //  all waves have been completed by the player 

        }
        else
        {
            nextWave++;                                   // decrementing the next wave of enemies to be spawnned; 
        }
        

    


    }


    // Enemy Alive System 
    bool EnemyIsAlve ()
    {
        searchCountDown -= Time.deltaTime;                         // the system is searching the count down to see if it is -= to time. delta time 
        if(searchCountDown <= 0f)                                 // if the search count down is greater or equal to 0 then
        {
            searchCountDown = 1f;                               // are search count down will equal 1 
            if (GameObject.FindGameObjectWithTag("Enemy") == null)          // if there is no enemy game object tag found then this tag will 
            {
                return false;                                              // return false and the enemy is dead 
            }
        }
        return true;                                                    // if the enemy tag gameobject is found then this statement will return true
    }

    // Spawn Waves are being excuted in intervales 
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave:" + _wave.name);                   // in the console we are going to display the name of the wave that is spawning
        state = SpawnState.Spawning;                               // the state meachine is set to the spawning state 

        for(int i = 0; i<_wave.count; i++)                       // for loop 
        {

            SpawnEnemy(_wave.enemy);                           // spawn the enmy 
            yield return new WaitForSeconds(1f / _wave.rate);      // then we are going to wait 1 second divided by the wave rate 
        }

        state = SpawnState.Waiting;                              // the state mechaine is now in the waiting state 


        yield break;                                           // we are going to break out of the coroutine 
    }

   


    // Enemy Spawning System 
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);

        Transform _SP = spawnPoints[Random.Range(0, spawnPoints.Length)];        // Allowing the system to set a random number of spawn points in the inspector 

        Instantiate(_enemy, _SP.position, _SP.rotation);                       // Cloing the enemy, Spawn Points position and Spawn point rotation 
       
    }
}


