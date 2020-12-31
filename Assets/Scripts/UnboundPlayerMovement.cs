﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;
 using Random = UnityEngine.Random;


public class UnboundPlayerMovement : MonoBehaviour
{
    public float forwardVelocity = 1000;
    public float baseForce = 5;
    public float boostMultiplier = 5;
    public float torque;
    public GameObject nitro;
    public GameObject oxygen;
    public TextMesh outtext;
    
    private Rigidbody rbody; //Astronaut RigidBody -> Fester Körper mit Physikalischen verhalten

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateLeft;
    private bool rotateRight;
    private bool boost;
    

    //- Energy (Nitro) Level
    public float energy = 100f;
    public float energy_step = 0.1f;
    private float energy_cont = 100f;

    //- Oxygen Level
    public float oxy_energy = 100f;
    public float oxy_step = 0.1f;
    private float oxygen_cont = 100f;

    //- Time spend
    private DateTime startTime;
    private int time_cont = 0;

    private float forceMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>(); //Abholen von Astronaut
        rbody.AddForce(Vector3.forward * forwardVelocity);
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)) * forceMultiplier); // Kraft (in 3D) anwenden um Bewegung zu starten
        // rbody.AddRelativeTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Rotierung
        
        startTime = DateTime.Now;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forceMultiplier = baseForce * boostMultiplier;
        } else
        {
            forceMultiplier = baseForce;
        }
        if (Input.GetKey(KeyCode.Escape)) // Escape
        {
            // Back to Startmenu or Exit Game
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetKey("w")) // UP
        {
            moveUp = true;
        }
        if (Input.GetKey("s")) // DOWN
        {
            moveDown = true;
        }
        if (Input.GetKey("a")) // LEFT
        {
            moveLeft = true;
        }
        if (Input.GetKey("d")) // RIGHT
        {
            moveRight = true;
        }
        if (Input.GetKey("c")) // ROTATE LEFT
        {
            rotateLeft = true;
        }
        if (Input.GetKey("v")) // ROTATE RIGHT
        {
            rotateRight = true;
        }
        
        //- Update Time
        var spendTime = DateTime.Now.Subtract(startTime);

        if (time_cont < spendTime.Seconds)
        {
            // Debug.Log(setZero(spendTime.Hours)+":"+setZero(spendTime.Minutes)+":"+setZero(spendTime.Seconds));

            outtext.text = setZero(spendTime.Hours) + ":" + 
                           setZero(spendTime.Minutes) + ":" +
                           setZero(spendTime.Seconds);
            if (spendTime.Seconds % 2 == 0)
            {
                oxy_energy = oxy_energy - oxy_step;
                ShowBottleLevel(oxygen, oxy_energy);
            }
        }
        //- Reset Control-Value
        time_cont = spendTime.Seconds;
    }

    // Called every physics update
    private void FixedUpdate()
    {
        if (moveUp)
        {
            rbody.AddForce(Vector3.up * forceMultiplier);
            //- Energy steps
            energy -= energy_step;
            moveUp = false;
        }
        if (moveDown)
        {
            rbody.AddForce(Vector3.down * forceMultiplier);
            //- Energy steps
            energy -= energy_step;
            moveDown = false;
        }
        if (moveLeft)
        {
            rbody.AddForce(Vector3.left * forceMultiplier);
            //- Energy steps
            energy -= energy_step;
            moveLeft = false;
        }
        if (moveRight)
        {
            rbody.AddForce(Vector3.right * forceMultiplier);
            //- Energy steps
            energy -= energy_step;
            moveRight = false;
        }
        if (rotateLeft)
        {
            rbody.AddRelativeTorque(Vector3.up * 0.1f);
            //- Energy steps
            energy -= energy_step;
            rotateLeft = false;
        }
        if (rotateRight)
        {
            rbody.AddRelativeTorque(Vector3.down * 0.1f);
            //- Energy steps
            energy -= energy_step;
            rotateRight = false;
        }

        // Update Nitrogen Level
        ShowBottleLevel(nitro, energy);
    }

    private void ShowBottleLevel(GameObject bottle,float value)
         {
             if (value >= 0)
             {
                 // check catch nitro/oxygen
                 if (energy_cont > value)
                 {
                     bottle.transform.Find("level.000").gameObject.SetActive(true);
                     bottle.transform.Find("level.001").gameObject.SetActive(true);
                     bottle.transform.Find("level.002").gameObject.SetActive(true);
                     bottle.transform.Find("level.003").gameObject.SetActive(true);
                     bottle.transform.Find("level.004").gameObject.SetActive(true);
                     bottle.transform.Find("level.005").gameObject.SetActive(true);
                     bottle.transform.Find("level.006").gameObject.SetActive(true);
                     bottle.transform.Find("level.007").gameObject.SetActive(true);
                     bottle.transform.Find("level.008").gameObject.SetActive(true);
                     bottle.transform.Find("level.009").gameObject.SetActive(true);
                 }
     
                 if (value < 90)
                 {
                     bottle.transform.Find("level.009").gameObject.SetActive(false);
                 }
                 if (value < 80)
                 {
                     bottle.transform.Find("level.008").gameObject.SetActive(false);
                 }
                 if (value < 70)
                 {
                     bottle.transform.Find("level.007").gameObject.SetActive(false);
                 }
                 if (value < 60)
                 {
                     bottle.transform.Find("level.006").gameObject.SetActive(false);
                 }
                 if (value < 50)
                 {
                     bottle.transform.Find("level.005").gameObject.SetActive(false);
                 }
                 if (value < 40)
                 {
                     bottle.transform.Find("level.004").gameObject.SetActive(false);
                 }
                 if (value < 30)
                 {
                     bottle.transform.Find("level.003").gameObject.SetActive(false);
                 }
                 if (value < 20)
                 {
                     bottle.transform.Find("level.002").gameObject.SetActive(false);
                 }
                 if (value < 10)
                 {
                     bottle.transform.Find("level.001").gameObject.SetActive(false);
     
                 }
                 if (value < 4)
                 {
                     bottle.transform.Find("level.000").gameObject.SetActive(false);
                 }
     
                 // set new control value
                 energy_cont = value;
             }
             else
             {
                 // Back to Startmenu
                 SceneManager.LoadScene("MainMenu");
             }
         }
    
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<GameManager>().EndGame(); // maybe do this different, not with find
    }

    private String setZero(int input)
    {
        if (input < 10)
        {
           return  $"0{input}";
        }

        return $"{input}";
    }
}

