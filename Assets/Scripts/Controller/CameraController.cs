using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 cameraPosition;

    private void Awake()
    {
        cameraPosition = new Vector3(0, 0, -10);
    }

    void LateUpdate()
    {
        // 예전에 카메라가 특정 범위를 벗어나지 않게 해본적이 있는데
        // 그 방식으로 할까 잠시 고민했다가 이번에도 시간 이슈가..
        transform.position = playerTransform.position + cameraPosition;
    }
}
