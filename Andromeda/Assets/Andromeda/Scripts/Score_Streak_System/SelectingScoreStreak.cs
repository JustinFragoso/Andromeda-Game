using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A SUBSET PART OF THE INVENTORY SYSTEM 

/* This class allows the player to swap between different score streaks in their inventory 
 * but only displays the UI for the selected score streak*/



public class SelectingScoreStreak : MonoBehaviour
{
    
    private int selectedScorestreakUI = 0;                // variable that will represent the number of UI Icons that are under a child game object




    void Start()
    {

        


    }


    void Update()
    {

       
        int previousSelectedIconUI = selectedScorestreakUI;


        // Mechanics for switching score streaks 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)          // if this is greater than 0 we scrolled up if this is less than 0 we scrolled down
        {


            if (selectedScorestreakUI >= transform.childCount - 1)
                selectedScorestreakUI = 0;
            else
                selectedScorestreakUI++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)           // if this is greater than 0 we scrolled up if this is less than 0 we scrolled down
        {

            if (selectedScorestreakUI <= 0)
                selectedScorestreakUI = transform.childCount - 1;

            else
                selectedScorestreakUI--;

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            selectedScorestreakUI = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
           
            selectedScorestreakUI = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
           
            selectedScorestreakUI = 3;
        }


        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
           
            selectedScorestreakUI = 3;
        }


        if (previousSelectedIconUI != selectedScorestreakUI)
        {
            SelectscorestreakUI();
        }

    }


    public void SelectscorestreakUI()
    {
        int i = 0;
        foreach (Transform scorestreakUI in transform)
        {
            if (i == selectedScorestreakUI)
            {
                scorestreakUI.gameObject.SetActive(true);
            }
            else
                scorestreakUI.gameObject.SetActive(false);
            i++;
        }
    }
}
