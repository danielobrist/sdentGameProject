using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController controller;
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rbody.AddForce(new Vector3(0, 1, 0)); 
        }
        if (Input.GetKey("s"))
        {
            rbody.AddForce(new Vector3(0, -1, 0));
        }
        if (Input.GetKey("a"))
        {
            rbody.AddForce(new Vector3(-1, 0, 0));

        }
        if (Input.GetKey("d"))
        {
            rbody.AddForce(new Vector3(1, 0, 0));
        }


    }
}

