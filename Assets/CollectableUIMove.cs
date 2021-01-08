using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO NOT WORKING YET

public class CollectableUIMove : MonoBehaviour
{
    [Range(-20f, 20f)]
    public float targetX = 9f;
    [Range(-20f, 20f)]
    public float targetY = 2.1f;
    [Range(0.01f, 20f)]
    public float targetZ = 2f;

    public float speed = 1.0f;
    public float closeEnough;

    private Vector2 targetPosition;
    private Vector2 currentPosition;
    private Transform objTransf;
    private float distanceToTarget;

    private GameObject collectableUIPrefab;
    public GameObject oxygenUIPrefab;
    public GameObject nitrogenUIPrefab;
   
    void Start()
    {
        objTransf = GetComponent<Transform>();
        currentPosition = objTransf.position;
        Debug.LogWarning("CollectableUIAsset position at init: " + currentPosition);

        targetPosition = new Vector3(targetX, targetY, targetZ);
        Debug.Log("targetPosition " + targetPosition);
    }

    public void SetResourceType(string resourceType)
    {
        switch (resourceType)
        {
            case "Oxygen":
                collectableUIPrefab = oxygenUIPrefab;
                break;
            case "Nitrogen":
                collectableUIPrefab = nitrogenUIPrefab;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        objTransf.localPosition = Vector2.Lerp(currentPosition, targetPosition, speed * Time.deltaTime);
        currentPosition = objTransf.localPosition;
        distanceToTarget = Vector2.Distance(currentPosition, targetPosition);
    }

    private void LateUpdate()
    {
        if (distanceToTarget < closeEnough)
        {
  
            Destroy(gameObject);
        }
    }
}
