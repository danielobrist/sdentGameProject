using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetPrefab;
    public int maxPlanets = 5;
    public float spawnArea = 500;

    private Asteroid asteroid;
    private NoiseSettings noiseSettings;
    private ShapeSettings shapeSettings;
    private ColorSettings colorSettings;


    public void SpawnPlanets()
    {
            GameObject clone = Instantiate(planetPrefab) as GameObject;
            clone.gameObject.tag = "Planet";
            clone.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + spawnArea);
    }
}