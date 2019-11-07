using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RIGHT NOW THIS IS A FLAT BALANCE LEVELING SYSTEM 
 * BUT SHOULD BE ADJUSTED LATER ON TO MAKE CERTAIN SHIPS
 * AND POWER UPS HARD TO GET WHICH WILL INCENTIVISE PLAYERS 
 * TO PLAY KEEP PLAYING THE GAME!
 */


public class LevelUp : MonoBehaviour
{

    //variables 
    public int level;                           // currerent level that the player is going to be at 
    private float expereince;                    // currerent expereince that the player has 
    private float expereinceRequired;           // the amount of expereince that is required for the player to hit the next level

    



    // Methods 
     void Start()
    {
        level = 1;                          // the player will be at level 1 as soon as they start they game
        expereince = 0;                    // the defealut value for exp will be set to zero at the start of the game.
        expereinceRequired = 100; 
    }


    void Update()
    {
        Exp();

        if (Input.GetKeyDown(KeyCode.E))       //TESTING THE SYSTEM TO SEE IF EVERY THING WORKS CORRECTLY!!!
        {
            expereince += 100;
        }
    }


    void RankUp()
    {
        level += 1;                     // level up the player 
        expereince = 0;                // experience will be set back to 0



        // Allows use to give the player something when they reach a certain level
        switch (level)
        {
            case 2:                     // if player hits lvl 2 
               // Give player an item
                expereinceRequired = 200;
                break;


            case 3:
                expereinceRequired = 300;
                print("Congrautlations you have hit level 3 on your character");
                break;

        }
    }


    void Exp()
    {
       
        if(expereince >= expereinceRequired)                       
        {
            RankUp(); 
        }
    }


}
