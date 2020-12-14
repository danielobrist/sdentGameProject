using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody; //Astronaut RigidBody -> Fester Körper mit Physikalischen verhalten
    public float torque;
    public GameObject oxygen;


    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateLeft;
    private bool rotateRight;
    private bool boost;

    public float energy = 100f;
    public float energy_step = 0.1f;
    private float energy_cont = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>(); //Abholen von Astronaut
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Kraft (in 3D) anwenden um Bewegung zu starten
        rbody.AddRelativeTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Rotierung
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Escape
        {
            // Back to Startmenu
            SceneManager.LoadScene("MainMenu");
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

    }

    // Called every physics update
    private void FixedUpdate()
    {

        if (moveUp)
        {
            rbody.AddForce(Vector3.up);
            //- Energy steps
            energy -= energy_step;
            moveUp = false;
        }
        if (moveDown)
        {
            rbody.AddForce(Vector3.down);
            //- Energy steps
            energy -= energy_step;
            moveDown = false;
        }
        if (moveLeft)
        {
            rbody.AddForce(Vector3.left);
            //- Energy steps
            energy -= energy_step;
            moveLeft = false;
        }
        if (moveRight)
        {
            rbody.AddForce(Vector3.right);
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
        ShowNitrogen(energy);
    }


    private void ShowNitrogen(float value)
    {
        if (value >= 0)
        {
            // check catch nitro
            if (energy_cont > value)
            {
                oxygen.transform.Find("level.000").gameObject.SetActive(true);
                oxygen.transform.Find("level.001").gameObject.SetActive(true);
                oxygen.transform.Find("level.002").gameObject.SetActive(true);
                oxygen.transform.Find("level.003").gameObject.SetActive(true);
                oxygen.transform.Find("level.004").gameObject.SetActive(true);
                oxygen.transform.Find("level.005").gameObject.SetActive(true);
                oxygen.transform.Find("level.006").gameObject.SetActive(true);
                oxygen.transform.Find("level.007").gameObject.SetActive(true);
                oxygen.transform.Find("level.008").gameObject.SetActive(true);
                oxygen.transform.Find("level.009").gameObject.SetActive(true);
            }

            if (value < 90)
            {
                oxygen.transform.Find("level.009").gameObject.SetActive(false);
            }
            if (value < 80)
            {
                oxygen.transform.Find("level.008").gameObject.SetActive(false);
            }
            if (value < 70)
            {
                oxygen.transform.Find("level.007").gameObject.SetActive(false);
            }
            if (value < 60)
            {
                oxygen.transform.Find("level.006").gameObject.SetActive(false);
            }
            if (value < 50)
            {
                oxygen.transform.Find("level.005").gameObject.SetActive(false);
            }
            if (value < 40)
            {
                oxygen.transform.Find("level.004").gameObject.SetActive(false);
            }
            if (value < 30)
            {
                oxygen.transform.Find("level.003").gameObject.SetActive(false);
            }
            if (value < 20)
            {
                oxygen.transform.Find("level.002").gameObject.SetActive(false);
            }
            if (value < 10)
            {
                oxygen.transform.Find("level.001").gameObject.SetActive(false);
                                                
            }
            if (value < 4)
            {
                oxygen.transform.Find("level.000").gameObject.SetActive(false);
            }
            
            // set new control value
            energy_cont = value;
        }
        else {
            // Back to Startmenu
            SceneManager.LoadScene("MainMenu");
        }
    }
}

