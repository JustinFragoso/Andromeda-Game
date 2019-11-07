using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // grants access to action delegates
using UnityEngine.UI; // Grants access to Unity UI system. 

public class PlayerStateMachine : MonoBehaviour
{
   

    private Dictionary<LocomotionStates, Action> fsm = new Dictionary<LocomotionStates, Action>();   // Gets access to the dirctionary that will be used throught the statemachine. 



    enum LocomotionStates                                           // Gets access to the different states with in the statemachein 
    {
        Idle,
        FlyLeft,
        FlyForward,
        FlyBackwards,
        FlyRight,
        Death,
     
    }

    private LocomotionStates curState = LocomotionStates.Idle;                              // the current state will always be set to Idle. 

    
    [SerializeField]
    private float speed = 0.0f;
    Animator anime;                             // gets a reference to the animator controller
    private float maxDeltaVel = 0.0f;          // reference to max velocity 
    private Rigidbody rb;                     // Get access to GetComponet<RigidBody>(). 

    public GameObject shot;                  // Reference to the Regular shot 
    public Transform shotSpawn;              // Reference to the shot spawn location 
    public float fireRate;                  // Reference to the player fire rate. 

    private float nextFire;                 // Reference to the next shot that will spawn out of the shot location. 

    public int startingHealth = 100;             // The amount of health that the player will start the game off with.
    public int currentHealth;                   // The current health that the player. 
    public Slider healthSlider;             // Reference to the UI health bar. 
    public AudioClip deathclip;               // This audio clip will play when the player dies. 

    AudioSource playerAudio;                 // Reference to the audio component. 
    bool isDead;                            // Wether the player is dead. 
    bool damaged;                          // True when the player gets damged. 

    private AudioSource audioSource;       // reference to the audip source component 

    // Setting up references. 
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();

        // Set the inital health of the player.
        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // Getting access to are Rigidbody component. 
        anime = GetComponent<Animator>();       // Getting acces to are animator component.

        if (anime == null)                     // If are animator return back null then debug the state mahcine and retrive the animator component. 
        {
            Debug.Log("ActorStateMachie: Start() . could not retrive the Animator component");
        }

        fsm.Add(LocomotionStates.Idle, new Action(Idle));             // Get acess to the Idle animation. 
        fsm.Add(LocomotionStates.FlyLeft, new Action(FlyLeft));       // Get access to the fly left amimation. 
        fsm.Add(LocomotionStates.FlyRight, new Action(FlyBackwards));  // Gets access to the fly backwards animation. 
        fsm.Add(LocomotionStates.FlyBackwards, new Action(FlyRight));   // Get access to the fly right animation. 
        fsm.Add(LocomotionStates.Death, new Action(Death));            // Get access to the death function. 

        audioSource = GetComponent<AudioSource>(); 
     
    }


    void Idle()
    {
        float h = Input.GetAxis("Horizontal");                      // Moves the players spacecraft along the Z axis forward and back. 
        float v = Input.GetAxis("Vertical");                        // Moves the players spacecraft alone the X axis left and right. 
        anime.SetFloat("Speed", v);
        anime.SetFloat("Direction", h);

        transform.Rotate(0, h, 0);                                // Reference to how the player rotation is affected on the Z axis.

        Vector3 targetDirection = transform.forward * v;         // Reference to the target driection that will allow the spacecraft to fly forward on the X axis. 

        Vector3 targetVelocity = targetDirection * speed;       // Reference the the target velocity "Speed" and the direction for the location that the spacecraft is traveling to. 

        Vector3 deltaVelocity = targetVelocity; GetComponent<Rigidbody>(); // Obtaining a reference from the game object physics component. 

        deltaVelocity.x = Mathf.Clamp(deltaVelocity.x, -maxDeltaVel, maxDeltaVel);  // Clamping the function 
        deltaVelocity.z = Mathf.Clamp(deltaVelocity.z, -maxDeltaVel, maxDeltaVel);  // CLamling the function 
        deltaVelocity.y = 0;

        GetComponent<Rigidbody>().AddForce(deltaVelocity, ForceMode.VelocityChange);    // Getting acess the game objects physics amd applying force to move the spacecraft.
    }

    void FlyLeft()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", v);
        anime.SetFloat("Direction", h);

        transform.Rotate(0, h, 0);

        Vector3 targetDirection = transform.forward * v;

        Vector3 targetVelocity = targetDirection * speed;

        Vector3 deltaVelocity = targetVelocity; GetComponent<Rigidbody>();

        deltaVelocity.x = Mathf.Clamp(deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.z = Mathf.Clamp(deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.y = 10;

        GetComponent<Rigidbody>().AddForce(deltaVelocity, ForceMode.VelocityChange);

        
    }

    void FlyForward()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", v);
        anime.SetFloat("Direction", h);

        transform.Rotate(0, h, 0);

        Vector3 targetDirection = transform.forward * v;

        Vector3 targetVelocity = targetDirection * speed;

        Vector3 deltaVelocity = targetVelocity; GetComponent<Rigidbody>();

        deltaVelocity.x = Mathf.Clamp(deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.z = Mathf.Clamp(deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.y = 0;

        GetComponent<Rigidbody>().AddForce(deltaVelocity, ForceMode.VelocityChange);
    }

    void FlyBackwards()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", v);
        anime.SetFloat("Direction", h);

        transform.Rotate(0, h, 0);

        Vector3 targetDirection = transform.forward * v;

        Vector3 targetVelocity = targetDirection * speed;

        Vector3 deltaVelocity = targetVelocity; GetComponent<Rigidbody>();

        deltaVelocity.x = Mathf.Clamp(deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.z = Mathf.Clamp(deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.y = 0;

        GetComponent<Rigidbody>().AddForce(deltaVelocity, ForceMode.VelocityChange);
    }

    void FlyRight()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", v);
        anime.SetFloat("Direction", h);

        transform.Rotate(0, h, 0);

        Vector3 targetDirection = transform.forward * v;

        Vector3 targetVelocity = targetDirection * speed;

        Vector3 deltaVelocity = targetVelocity; GetComponent<Rigidbody>();

        deltaVelocity.x = Mathf.Clamp(deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.z = Mathf.Clamp(deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
        deltaVelocity.y = 0;

        GetComponent<Rigidbody>().AddForce(deltaVelocity, ForceMode.VelocityChange);
    }

   

    void SetState(LocomotionStates newstate)
    {
        curState = newstate;                // Reference to the currents state and then transiting to the a new state when action inputs are pressed. 
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
           
        }
        fsm[curState].Invoke();                                     // Offers a time delay on the state curstate this is running. 
       
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        // reduce the current health by the damage amount. 
        currentHealth -= amount;

        // Set the health bar's slider to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect. 
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set.. 
        if (currentHealth <= 0 && !isDead) 
        {
            //... the player should die.
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again. 
        isDead = true;

        Destroy(gameObject);    // Destroy the player. 

    }
}


