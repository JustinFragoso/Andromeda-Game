using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary                                    // This class will allow us to grant access to the games bounadry 
{
    public float xMin, xMax, zMin, zMax;    // this allows us to defind the values for are boundary
}

public class Playercontroller : MonoBehaviour { 

    private Rigidbody rb;                                   // Grants access to the rigidbody component 

    public float speed;                                   // variable that will allow us to set the speed for which the spacecraft will move 
    public float tilt;                                   // variable that will allow us to set the amount of tilt of are spacecraft 
    public Boundary boundary;                           // instances that will allow us to set the boundary amounts in the inspector 

    public GameObject shot;                            // grants access to the shot gameobject 
    public Transform [] shotSpawns;                       //  grants access to the shot transform 
    public float fireRate;                           //  variable that allow us to set the fire rate of the spacecraft 
    private float nextFire;                         // variable that will allow the next shot to be fired after a certain amount of seconds 



    AudioSource playerAudio;                             // Reference to the audio component. 
    private AudioSource audioSource;                    // Audio source instances 
  

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
       audioSource  = GetComponent<AudioSource>();     // getting the audio source componet 
        rb = GetComponent<Rigidbody>();         // obtaining the rigidbody componet 
    }



    void Update()
    {
        // Fire Mechanic                                             
        if (Input.GetButton("Fire1") && Time.time > nextFire)             /* if the user presses down on the left mouse button and time.time is 
                                                                         greater then fire then   */
        {
            nextFire = Time.time + fireRate;                           /* are next fire will be equal to time.time plus the shot fire rate 
                                                                          and it will then */
            foreach(var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation); /* cloning the shot game object at both its spawn position
                                                                       and spawn rotation and spawn it in to the game */

            }

            audioSource.Play();                                       // playing the shot audio


        }

    }



    // Core Physic System Mechanics 
    void FixedUpdate()
    {                                                            // Mechanics 
        float moveHorizontal = Input.GetAxis("Horizontal");     // this will allow us to move the spacecraft left and right 
        float moveVertical = Input.GetAxis("Vertical");        // this will allow us to move the spacecraft up and down 

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);   // taking in three parameters that will move the spacecraft


        rb.velocity = movement * speed;                                    
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),       /* we are clamping the values for xMin and xMax to make sure 
                                                                           that they do go over the values of 0.0f */
            0.0f,                                                          // this variable will control values in the y position 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)       // we are clamping the values for zMin and zMax to make sure that they do go over the values of 0.0f
        );

        rb.rotation = Quaternion.Euler(0.0f, 180f, rb.velocity.x * tilt);  // This allows us to change the values for the rotation of the game object
    }

   

}
