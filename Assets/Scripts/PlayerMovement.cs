using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        rbody.AddTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rbody.AddForce(new Vector3(0f, 1f, 0f)); 
        }
        if (Input.GetKey("s"))
        {
            rbody.AddForce(new Vector3(0f, -1f, 0f));
        }
        if (Input.GetKey("a"))
        {
            rbody.AddForce(new Vector3(-1f, 0f, 0f));
        }
        if (Input.GetKey("d"))
        {
            rbody.AddForce(new Vector3(1f, 0f, 0f));
        }


    }
}

