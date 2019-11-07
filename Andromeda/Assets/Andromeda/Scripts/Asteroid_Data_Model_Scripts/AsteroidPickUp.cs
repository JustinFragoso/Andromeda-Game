using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPickUp : MonoBehaviour
{
    public int scoreValue;                              // reference int for the score value. 

    private GameController gameController;              // reference to the game controller. 

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");         // we are finding and locating the game controller by its tag 
        if (gameController != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();          // we are getting the game controller component from the game controller script  
        }
        if (gameController == null) 
        {
            Debug.Log("Cann 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)                // Allows two objects to collided together to perform certain functions. 
    {
        Destroy(other.gameObject);                    // Destroy object with the tag pick up.
        if (other.gameObject.CompareTag("Pick Up"))    // Reference to the game object that is tag pickup.
        {
            other.gameObject.SetActive(false);
        }
    }

}
   
   