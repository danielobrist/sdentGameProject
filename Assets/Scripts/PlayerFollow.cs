using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    private void FixedUpdate()
    {
        Vector3 oldPos = transform.position;
        Vector3 newPos = playerTransform.position + cameraOffset;
        Vector3 cameraToAstronaut = playerTransform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, cameraToAstronaut);

        transform.position = new Vector3(Mathf.Lerp(oldPos.x, newPos.x, Time.deltaTime * angle * smoothFactor),
                                           Mathf.Lerp(oldPos.y, newPos.y, Time.deltaTime * angle * smoothFactor),
                                           newPos.z) ;
    }
}
