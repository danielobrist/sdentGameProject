﻿using UnityEngine;

public class IdleAsteroid : MonoBehaviour
{
    private Rigidbody rbody;
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
            GetComponent<AudioSource>().Play();
            PlayerScore.Alive = false;
            FindObjectOfType<GameManager>().EndGame(); // maybe do this with static class instead of Find
        }
    }
}
