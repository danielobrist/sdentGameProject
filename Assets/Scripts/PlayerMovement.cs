using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private float energy = 100f;
    private float energy_step = 0.5f;

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
        // Beschleunigunswert abziehen von Stickstoff
        oxygen.transform.Find("level.000").gameObject.SetActive(false);
        oxygen.transform.Find("level.001").gameObject.SetActive(false);

        if (moveUp)
        {
            rbody.AddForce(Vector3.up);
            //- Energy steps
            energy -= energy_step;
            //System.Console.WriteLine("energy: " + energy);
            Debug.Log("energy: " + energy);
            moveUp = false;
        }
        if (moveDown)
        {
            rbody.AddForce(Vector3.down);
            energy -= energy_step;
            //System.Console.WriteLine("energy: " + energy);
            Debug.Log("energy: " + energy);
            moveDown = false;
        }
        if (moveLeft)
        {
            rbody.AddForce(Vector3.left);
            energy -= energy_step;
            System.Console.WriteLine("energy: " + energy);
            moveLeft = false;
        }
        if (moveRight)
        {
            rbody.AddForce(Vector3.right);
            energy -= energy_step;
            System.Console.WriteLine("energy: " + energy);
            moveRight = false;
        }
        if (rotateLeft)
        {
            rbody.AddRelativeTorque(Vector3.up * 0.1f);
            energy -= energy_step;
            System.Console.WriteLine("energy: " + energy);
            rotateLeft = false;
        }
        if (rotateRight)
        {
            rbody.AddRelativeTorque(Vector3.down * 0.1f);
            energy -= energy_step;
            System.Console.WriteLine("energy: " + energy);
            rotateRight = false;
        }
    }

}

