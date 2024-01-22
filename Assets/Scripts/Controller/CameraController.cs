using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 cameraPosition;

    private void Awake()
    {
        cameraPosition = new Vector3(0, 0, -10);
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraPosition;
    }
}
