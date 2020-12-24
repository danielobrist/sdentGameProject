using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform playerTransform;

    private Vector3 cameraOffset;
    private float helpCameraFollowFaster = 10;
    private Vector3 velocity = Vector3.zero;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    // Start is called before the first frame update
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

        // transform.LookAt(playerTransform);
    }
}
