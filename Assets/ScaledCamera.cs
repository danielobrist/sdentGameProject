using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaledCamera : MonoBehaviour
{

    public Camera mainCamera;
    public Transform referencePoint;

    [Range(1.0f, 20000.0f)]
    public float scaleFactor = 20000;

    private Vector3 oldMainCamPos;
    private Vector3 newMainCamPos;

    Vector3 movedAmout;
    Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        oldMainCamPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.rotation = mainCamera.transform.rotation;

        newMainCamPos = mainCamera.transform.position;
        diff = mainCamera.transform.position - oldMainCamPos;
        transform.position = transform.position + diff / scaleFactor;
        oldMainCamPos = newMainCamPos;
    }
}
