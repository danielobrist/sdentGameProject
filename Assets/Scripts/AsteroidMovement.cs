using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody rbody;

    public float velocity = Random.Range(1f, 10f);

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        rbody.AddTorque(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        rbody.AddForce(Vector3.back * velocity);
    }
}
