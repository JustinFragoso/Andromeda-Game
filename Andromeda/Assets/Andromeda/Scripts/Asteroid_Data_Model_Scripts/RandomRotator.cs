using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;                   
    private Rigidbody rb;                                       // private function to access the get rigidbody component. 
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;      // all the spehere tumble at an angular velocity at random.       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
