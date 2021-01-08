using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleType : MonoBehaviour
{
    public GameObject CollectType;
    public string ResourceType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
