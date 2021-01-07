using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particlePrefab;
    public int numberOfParticles = 100;
    public float spawnArea = 20;


    public void spawnParticles()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            GameObject clone = Instantiate(particlePrefab) as GameObject;
            clone.gameObject.tag = "Destroy";
            clone.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-spawnArea, spawnArea));
        }
    }
}
