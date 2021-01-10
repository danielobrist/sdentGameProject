using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGenerator : MonoBehaviour
{
    public GameObject collectable1;
    public GameObject collectable2;
    public int numberOfCollectables = 20;
    public float spawnArea = 20;

    private float scaleInTime = 2.0f;
    public void SpawnCollectables()
    {
        for (int i = 0; i < numberOfCollectables; i++)
        {
            GameObject clone1 = Instantiate(collectable1) as GameObject;
            clone1.gameObject.tag = "Collectable";
            clone1.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-400, 400));
            clone1.transform.localScale = Vector3.zero;
            StartCoroutine("SmoothScaleIn", clone1);

            GameObject clone2 = Instantiate(collectable2) as GameObject;
            clone2.gameObject.tag = "Collectable";
            clone2.transform.position = new Vector3(transform.position.x + Random.Range(-spawnArea, spawnArea), transform.position.y + Random.Range(-spawnArea, spawnArea), transform.position.z + Random.Range(-400, 400));
            clone2.transform.localScale = Vector3.zero;
            StartCoroutine("SmoothScaleIn", clone2);
        }
    }

    IEnumerator SmoothScaleIn(GameObject clone)
    {
        // Randomize scale up starting time to minimize pop up effect
        float randomTimer = Random.Range(0f, 2f);
        while (randomTimer > 0f)
        {
            randomTimer -= Time.deltaTime;
            yield return null;
        }

        Vector3 startingScale = Vector3.zero;
        Vector3 scaledScale = collectable1.transform.localScale;
        float i = 0f;
        while (i < scaleInTime)
        {
            i += Time.deltaTime;
            clone.transform.localScale = Vector3.Lerp(startingScale, scaledScale, i);
            yield return null;
        }
        yield return null;

    }
}
