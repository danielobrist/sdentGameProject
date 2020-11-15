using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;
    public float torque;

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
            rbody.AddForce(Vector3.up); 
        }
        if (Input.GetKey("s"))
        {
            rbody.AddForce(Vector3.down);
        }
        if (Input.GetKey("a"))
        {
            rbody.AddForce(Vector3.left);
        }
        if (Input.GetKey("d"))
        {
            rbody.AddForce(Vector3.right);
        }
        if (Input.GetKey("c"))
        {
            rbody.AddRelativeTorque(Vector3.up * 0.1f);
        }
        if (Input.GetKey("v"))
        {
            rbody.AddRelativeTorque(Vector3.down * 0.1f);
        }
    }

}

