using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    public float speed;                                     // var that will represent the enemy speed 
    private Rigidbody rb;                                   // var that will allow us to access the rigidbody component of the enemy spacecraft


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                // Obtaining the enemy rigidbody 
        rb.velocity = transform.forward * speed;      // obtaining the enemy velocity and moving it forwo
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
