using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAsteroid : MonoBehaviour
{
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        rbody.AddTorque(new Vector3(Random.Range(-5f, 50f), Random.Range(-5f, 50f), Random.Range(-5f, 50f)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            FindObjectOfType<GameManager>().EndGame(); // maybe do this different, not with find
        }
    }
}
