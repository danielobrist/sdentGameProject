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
    public TextMesh timeText;
    public TextMesh scoreText;
    
    //- Thruster INIT
    public GameObject thrusterB1;
    public GameObject thrusterB2;
    public GameObject thrusterRight;
    public GameObject thrusterLeft;
    public GameObject thrusterTop;
    private float thrusterxScale = 0.21418f;
    
    private Rigidbody rbody; //Astronaut RigidBody -> Fester Körper mit Physikalischen verhalten

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateLeft;
    private bool rotateRight;
    private bool boost;
    private bool outOfEnergy;
    private bool controlLost = false;

    //- Energy (Nitro) Level
    public float energy = 100f;
    public float energy_step = 0.1f;
    private float energy_cont = 100f;
    public TextMesh nitroOutText;

    //- Oxygen Level
    public float oxy_energy = 100f;
    public float oxy_step = 0.5f;
    private float oxygen_cont = 100f;
    public TextMesh oxygenOutText;

    //- Time spend
    private DateTime startTime;
    private int time_cont = 0;

    private float forceMultiplier = 1;
    
    //- Score View
    private int scoreCount = 10;
    private int scoreLevel = 1;
    private int scoreINTTXT = 0;
    private bool alive = true;
    
    //- Pickup Bottle Scaling
    public float pickupScaleFactor = 1.1f;
    public float pickupScaleDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            energy_step = 0.01f;
        }

        rbody = GetComponent<Rigidbody>(); //Abholen von Astronaut
        rbody.AddForce(Vector3.forward * forwardVelocity);
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)) * forceMultiplier); // Kraft (in 3D) anwenden um Bewegung zu starten
        // rbody.AddRelativeTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Rotierung
        
        startTime = DateTime.Now;

        thrusterB1 = GameObject.Find("ThrusterBottom1");
        thrusterB2 = GameObject.Find("ThrusterBottom2");
        thrusterRight = GameObject.Find("ThrusterRight");
        thrusterLeft = GameObject.Find("ThrusterLeft");
        thrusterTop = GameObject.Find("ThrusterTop");
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            //Accelerometer controls
            if (Input.acceleration.y + 0.5f > 0.1f)
            {
                moveUp = true;
            }
            if (Input.acceleration.y + 0.5f < -0.1f)
            {
                moveDown = true;
            }
            if (Input.acceleration.x < -0.1f)
            {
                moveLeft = true;
            }
            if (Input.acceleration.x > 0.1f)
            {
                moveRight = true;
            }
        }
            


        //Keyboard Controls
        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.Space))
        {
            forceMultiplier = baseForce * boostMultiplier;
            //- Boost visualisation
            setBoosterView(0.4f);
            
        } else
        {
            forceMultiplier = baseForce;
            if (thrusterxScale > 0.21418f)
            {
                setBoosterView(0.21418f);
            }
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
        if (energy > 0 && !outOfEnergy)
        {
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
        } else
        {
            outOfEnergy = true;
        }
          
        //- Update Time
        var spendTime = DateTime.Now.Subtract(startTime);

        if (time_cont < spendTime.Seconds)
        {
            // Debug.Log(setZero(spendTime.Hours)+":"+setZero(spendTime.Minutes)+":"+setZero(spendTime.Seconds));

            timeText.text = setZero(spendTime.Hours) + ":" + 
                            setZero(spendTime.Minutes) + ":" +
                            setZero(spendTime.Seconds);

            oxy_energy = oxy_energy - oxy_step;
            
            //- Calculate Score
            scoreINTTXT += (int)(scoreCount * scoreLevel);
            if (alive)
            {
                scoreINTTXT += (int)(scoreCount * scoreLevel);
            }

            scoreText.text = "Score: " + scoreINTTXT;

        }
        //- Reset Control-Value
        time_cont = spendTime.Seconds;

        // Update Bottle Level
        ShowBottleLevel(nitro, energy);
        ShowBottleLevel(oxygen, oxy_energy);
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

        

        if (outOfEnergy && !controlLost)
        {
            rbody.AddTorque(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
            controlLost = true;
        }
    }

    private void ShowBottleLevel(GameObject bottle,float value)
     {
         if (bottle.gameObject.name.Equals("Oxygen_Bottle"))
         {
             oxygenOutText.text = (int)value + "%";
         }
         if (bottle.gameObject.name.Equals("Nitro_Bottle"))
         {
             nitroOutText.text = (int)value + "%";
         }

         if (value >= 0)
         {
             // check catch nitro/oxygen
             if (energy >= value || oxy_energy >= value)
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
         }
         else
         {
             if (bottle.gameObject.name.Equals("Oxygen_Bottle"))
             {
                 alive = false;
                // Back to Startmenu
                SceneManager.LoadScene("Game_Over");
             }
         }
     }
    
    


    private String setZero(int input)
    {
        if (input < 10)
        {
           return  $"0{input}";
        }

        return $"{input}";
    }

    public void addOxygen()
    {
        oxy_energy = 100;
        ShowBottleLevel(oxygen, oxy_energy);
        StartCoroutine("ScaleUpDown", oxygen);
        scoreLevel++;
    }

    public void addNitrogen()
    {
        outOfEnergy = false;
        energy = 100;
        ShowBottleLevel(nitro, energy);
        StartCoroutine("ScaleUpDown", nitro);
        scoreLevel++;
    }
    
    private void setBoosterView(float ttxScale)
    {
        thrusterxScale = ttxScale;
        thrusterB1.gameObject.transform.localScale     = new Vector3(ttxScale,0.21418f,0.1018019f);
        thrusterB2.gameObject.transform.localScale     = new Vector3(ttxScale,0.21418f,0.1018019f);
        thrusterRight.gameObject.transform.localScale  = new Vector3(ttxScale,0.21418f,0.1018019f);
        thrusterLeft.gameObject.transform.localScale   = new Vector3(ttxScale,0.21418f,0.1018019f);
        thrusterTop.gameObject.transform.localScale    = new Vector3(ttxScale,0.21418f,0.1018019f);
    }

    IEnumerator ScaleUpDown(GameObject bottle)
    {
        Vector3 startingScale = nitro.transform.localScale;
        Vector3 scaledScale = startingScale * pickupScaleFactor;
        float i = 0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime * 10f;
            bottle.transform.localScale = Vector3.Lerp(startingScale, scaledScale, i);
            yield return null;
        }
        i = 0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime * 7f;
            bottle.transform.localScale = Vector3.Lerp(scaledScale, startingScale, i);
            yield return null;
        }
        yield return null;

    }

}

