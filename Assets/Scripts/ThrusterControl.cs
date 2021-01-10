using UnityEngine;

public class ThrusterControl : MonoBehaviour
{
    public ParticleSystem thrusterBottom1;
    public ParticleSystem thrusterBottom2;
    public ParticleSystem thrusterRight;
    public ParticleSystem thrusterLeft;
    public ParticleSystem thrusterTop;

    void Update()
    {
        if (AstronautMovement.energy > 0)
        {
            if (Input.GetKey("w"))
            {
                startThrust(thrusterBottom1);
                startThrust(thrusterBottom2);
            }
            else
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
        } else
        {
            stopThrust(thrusterBottom1);
            stopThrust(thrusterBottom2);
            stopThrust(thrusterTop);
            stopThrust(thrusterRight);
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
