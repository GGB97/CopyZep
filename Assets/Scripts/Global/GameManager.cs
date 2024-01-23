using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    CameraController mainCamera;
    [SerializeField] TMP_Text timeText;

    GameObject playerPrefab;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main.GetComponent<CameraController>();

        int idx = PlayerPrefs.GetInt("PlayerCharIndex");
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // �̷��� �ҰŸ� �׳� prefab�� �������� �Ǵ°� �ƴѰ�?
    }

    private void Update()
    {
        UpdateTime();
    }

    private void Start()
    {
        GameObject player = Instantiate(playerPrefab);
        mainCamera.playerTransform = player.transform;
    }

    void UpdateTime()
    {
        // ���� �ð��� �����ͼ� �ؽ�Ʈ�� ��ȯ
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // �ؽ�Ʈ ������Ʈ
        timeText.text = timeString;
    }
}
