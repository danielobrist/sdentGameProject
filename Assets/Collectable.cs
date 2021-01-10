using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddTorque(new Vector3(Random.Range(-5f, 50f), Random.Range(-5f, 50f), Random.Range(-5f, 50f)));
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Astronaut"))
        {
            
            if (gameObject.GetComponent<CollectibleType>().ResourceType.Equals("Oxygen"))
            {
                other.gameObject.GetComponent<UnboundPlayerMovement>().addOxygen();
            }

            if (gameObject.GetComponent<CollectibleType>().ResourceType.Equals("Nitrogen"))
            {
                other.gameObject.GetComponent<UnboundPlayerMovement>().addNitrogen();
            }

            //Destroy picked up collectable
            Destroy(gameObject);
        }
    }
}
