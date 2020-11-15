using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 3f;
    public float spawnArea = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
        asteroid.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(0f, 1f));
    }

    IEnumerator asteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
        }
    }
}
