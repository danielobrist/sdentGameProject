using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numberOfAsteroids = 100;
    public float spawnArea = 20;
    
    private Asteroid asteroid;
    private NoiseSettings noiseSettings;
    private ShapeSettings shapeSettings;
    private ColorSettings colorSettings;


    public void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            GameObject clone = Instantiate(asteroidPrefab) as GameObject;
            clone.gameObject.tag = "Destroy";
            clone.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-spawnArea, spawnArea));
        }
    }
}
