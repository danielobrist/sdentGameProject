using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;
    public float torque;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateLeft;
    private bool rotateRight;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        rbody.AddRelativeTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            moveUp = true;
        }
        if (Input.GetKey("s"))
        {
            moveDown = true;
        }
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
        if (Input.GetKey("c"))
        {
            rotateLeft = true;
        }
        if (Input.GetKey("v"))
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
            moveUp = false;
        }
        if (moveDown)
        {
            rbody.AddForce(Vector3.down);
            moveDown = false;
        }
        if (moveLeft)
        {
            rbody.AddForce(Vector3.left);
            moveLeft = false;
        }
        if (moveRight)
        {
            rbody.AddForce(Vector3.right);
            moveRight = false;
        }
        if (rotateLeft)
        {
            rbody.AddRelativeTorque(Vector3.up * 0.1f);
            rotateLeft = false;
        }
        if (rotateRight)
        {
            rbody.AddRelativeTorque(Vector3.down * 0.1f);
            rotateRight = false;
        }
    }

}

