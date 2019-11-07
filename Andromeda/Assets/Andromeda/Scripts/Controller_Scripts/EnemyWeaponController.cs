using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public GameObject shot;                                              // reference to the shot game object 
    public Transform shotSpawn;                                         // reference to the shot spawn transform
    public float fireRate;                                             // reference that will allow us to set the fire rate of the enemy in the inspector 
    public float delay;                                               // reference that will allow us to set the amount at which the enemy shot will delay in the inspector 

   private AudioSource audioSource;                               // reference to the audio source component 


    // Start is called before the first frame update

    void Start()
    {
      audioSource = GetComponent<AudioSource>();              // obtaining the audio source component 
        InvokeRepeating("Fire", delay, fireRate);              // this mechanic is firing a shot then delaying the next shot by it's fireRate 
    }

    // Enemy firing system 
   void Fire()
  {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);     // cloing the shot gameobject at both its position and rotation 
       

    }

}
