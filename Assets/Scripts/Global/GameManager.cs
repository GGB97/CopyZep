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
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // 이렇게 할거면 그냥 prefab을 가져오면 되는거 아닌가?
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
        // 현재 시간을 가져와서 텍스트로 변환
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // 텍스트 업데이트
        timeText.text = timeString;
    }
}
