using UnityEngine;

public class CollectableType : MonoBehaviour
{
    public string ResourceType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}