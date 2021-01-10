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
            
            if (gameObject.GetComponent<CollectableType>().ResourceType.Equals("Oxygen"))
            {
                other.gameObject.GetComponent<AstronautMovement>().addOxygen();
            }

            if (gameObject.GetComponent<CollectableType>().ResourceType.Equals("Nitrogen"))
            {
                other.gameObject.GetComponent<AstronautMovement>().addNitrogen();
            }

            //Destroy picked up collectable
            Destroy(gameObject);
        }
    }
}
