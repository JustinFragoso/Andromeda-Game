using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject pannelGameOverUI;

    private bool gameOver;


    void Start()
    {
        gameOver = false;

      
    
       
    }

    void Update()
    {
     
    }

  

    public void GameOver()
    {
        if (pannelGameOverUI != null)
        {
            pannelGameOverUI.SetActive(true);
            gameOver = true;
        }
      
    }
}


