using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numberOfAsteroids = 1000;
    public float spawnArea = 400;

    public void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            GameObject clone = Instantiate(asteroidPrefab) as GameObject;
            clone.gameObject.tag = "Asteroid";
            clone.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-spawnArea, spawnArea));
        }
    }
}
