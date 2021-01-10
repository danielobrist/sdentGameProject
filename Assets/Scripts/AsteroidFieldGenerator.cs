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
            clone.transform.localScale = Vector3.zero;
            StartCoroutine("SmoothScaleIn", clone);
        }
    }

    IEnumerator SmoothScaleIn(GameObject clone)
    {
        //Randomize scale up starting time to minimize pop up effect
        float randomTimer = Random.Range(0f, 1f);
        while (randomTimer > 0f)
        {
            randomTimer -= Time.deltaTime;
            yield return null;
        }

        Vector3 startingScale = Vector3.zero;
        float scaleFactor = Random.Range(0.5f, 5f);
        Vector3 scaledScale = asteroidPrefab.transform.localScale * scaleFactor;
        float i = 0f;
        while (i < 2.0f)
        {
            i += Time.deltaTime;
            clone.transform.localScale = Vector3.Lerp(startingScale, scaledScale, i * 1/scaleFactor);
            yield return null;
        }
        yield return null;

    }
}
