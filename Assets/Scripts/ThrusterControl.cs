using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterControl : MonoBehaviour
{
    public ParticleSystem thrusterBottom1;
    public ParticleSystem thrusterBottom2;
    public ParticleSystem thrusterRight;
    public ParticleSystem thrusterLeft;
    public ParticleSystem thrusterTop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            startThrust(thrusterBottom1);
            startThrust(thrusterBottom2);
        } else
        {
            stopThrust(thrusterBottom1);
            stopThrust(thrusterBottom2);
        }

        if (Input.GetKey("s"))
        {
            startThrust(thrusterTop);
        }
        else
        {
            stopThrust(thrusterTop);
        }

        if (Input.GetKey("a"))
        {
            startThrust(thrusterRight);
        }
        else
        {
            stopThrust(thrusterRight);
        }

        if (Input.GetKey("d"))
        {
            startThrust(thrusterLeft);
        }
        else
        {
            stopThrust(thrusterLeft);
        }
    }

    public void startThrust(ParticleSystem thruster)
    {
        if (!thruster.isEmitting)
        {
            thruster.Play();
        }
    }

    public void stopThrust(ParticleSystem thruster)
    {
        if (thruster.isEmitting)
        {
            thruster.Pause();
            thruster.Clear();
        }   
    }
}
