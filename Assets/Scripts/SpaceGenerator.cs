using UnityEngine;

public class SpaceGenerator : MonoBehaviour
{

    public GameObject spacePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Astronaut")
        {
            GameObject newSpace = Instantiate(spacePrefab) as GameObject;
            newSpace.name = "Space";
            Vector3 velocity = other.attachedRigidbody.velocity;
            newSpace.transform.position = other.attachedRigidbody.transform.position + velocity.normalized * 800f;
            //newSpace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 800f);
            newSpace.SetActive(true);
            newSpace.GetComponent<AsteroidFieldGenerator>().SpawnAsteroids();
            newSpace.GetComponent<CollectableGenerator>().SpawnCollectables();
        }
        
    }
}
