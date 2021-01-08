using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGenerator : MonoBehaviour
{
    public GameObject collectable1;
    public GameObject collectable2;
    public int numberOfCollectables = 20;
    public float spawnArea = 20;

    public void SpawnCollectables()
    {
        for (int i = 0; i < numberOfCollectables; i++)
        {
            GameObject clone1 = Instantiate(collectable1) as GameObject;
            clone1.gameObject.tag = "Collectable";
            clone1.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-400, 400));

            GameObject clone2 = Instantiate(collectable2) as GameObject;
            clone2.gameObject.tag = "Collectable";
            clone2.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-400, 400));
        }
    }
}
