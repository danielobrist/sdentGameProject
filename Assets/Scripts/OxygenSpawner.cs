using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSpawner : MonoBehaviour
{
    public GameObject oxygenPrefab;
    public float respawnTime = 3f;
    public float spawnArea = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OxygenWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OxygenWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnOxygen();
        }
    }

    private void SpawnOxygen()
    {
        GameObject asteroid = Instantiate(oxygenPrefab) as GameObject;
        asteroid.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(0f, 1f));
    }

}

