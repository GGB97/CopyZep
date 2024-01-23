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
        // ������ ī�޶� Ư�� ������ ����� �ʰ� �غ����� �ִµ�
        // �� ������� �ұ� ��� ����ߴٰ� �̹����� �ð� �̽���..
        transform.position = playerTransform.position + cameraPosition;
    }
}
