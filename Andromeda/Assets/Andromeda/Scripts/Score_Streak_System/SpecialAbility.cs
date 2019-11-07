using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// THERE IS A BUG THAT DOES NOT ALLOW THE USER TO SWITHC BETWEEN SCORE STREAKS WHEN PRESSING DOWN ON THE 1 KEY 

public class SpecialAbility : MonoBehaviour
{
    [SerializeField]
    public int selectedScorestreak = 0;                                 // var for the index the player score streaks



    void Start()
    {

        


    }


    void Update()
    {

        int previousSelectedscorestreak = selectedScorestreak;     // are previous score streak is equal are selected score streak

        #region
        // Mechanics for switching score streaks 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)          // if this is greater than 0 we scrolled up if this is less than 0 we scrolled down
        {
            if (selectedScorestreak >= transform.childCount - 1)
                selectedScorestreak = 0;
            else
                selectedScorestreak++;
            Debug.Log("You scrolled up");

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)           // if this is greater than 0 we scrolled up if this is less than 0 we scrolled down
        {
            if (selectedScorestreak <= 0)
                selectedScorestreak = transform.childCount - 1;

            else
                selectedScorestreak--;



        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedScorestreak = 1;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedScorestreak = 2;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedScorestreak = 3;

        }


        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedScorestreak = 4;

        }


        if (previousSelectedscorestreak != selectedScorestreak)           /* if are preivous selected score streak is not equal to are current 
                                                                          selected score then...*/
        {
            Selectscorestreak();                                        // we are going to call the selected score streak method 
        }
        #endregion

    }



    public void Selectscorestreak()
    {
        int i = 0;
        foreach (Transform scorestreak in transform)
        {
            if (i == selectedScorestreak)
            {
                scorestreak.gameObject.SetActive(true);
            }
           else
                scorestreak.gameObject.SetActive(false);
            i++;
        }


    }

}


