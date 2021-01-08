using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGenerator : MonoBehaviour
{

    public GameObject spacePrefab;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Astronaut")
        {
            Debug.Log("Astronaut entered new Space");
            GameObject newSpace = Instantiate(spacePrefab) as GameObject;
            newSpace.name = "Space";
            newSpace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 800f);
            newSpace.SetActive(true);
            newSpace.GetComponent<AsteroidFieldGenerator>().SpawnAsteroids();
            //newSpace.GetComponent<PlanetGenerator>().SpawnPlanets(); //disabled because planets were not being destroyed somehow
            newSpace.GetComponent<CollectableGenerator>().SpawnCollectables();
        }
        
    }
}
