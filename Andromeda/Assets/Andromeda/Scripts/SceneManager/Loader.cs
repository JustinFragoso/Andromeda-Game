using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
                                                               
    public enum Scene                                          // An Array for all scene that we wish to load 
    {
        AndromedaGame,                                        // Refernece to the Andromeda Game Scene 
    }

    public static void Load(Scene scene)                    // This class allows us to call a scene to be loaded 
    {
        SceneManager.LoadScene(scene.ToString());          // This function allows us to load a particular scene 
    }
}
