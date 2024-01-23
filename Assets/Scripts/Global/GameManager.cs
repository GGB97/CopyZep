using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    CameraController mainCamera;
    [SerializeField] TMP_Text timeText;

    GameObject playerPrefab;
    GameObject playerObj;

    [SerializeField] GameObject changeNameObj;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main.GetComponent<CameraController>();

        int idx = PlayerPrefs.GetInt("PlayerCharIndex");
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // 이렇게 할거면 그냥 prefab을 가져오면 되는거 아닌가?

        changeNameObj.SetActive(false);
    }

    private void Update()
    {
        UpdateTime();
    }

    private void Start()
    {
        playerObj = Instantiate(playerPrefab);
        mainCamera.playerTransform = playerObj.transform;
    }

    void UpdateTime()
    {
        // 현재 시간을 가져와서 텍스트로 변환
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // 텍스트 업데이트
        timeText.text = timeString;
    }
    public void ChangeNameStart()
    {
        changeNameObj.SetActive(true);
    }

    public void ChangeNameComplete()
    {
        string playerName = changeNameObj.GetComponentInChildren<TMP_InputField>().text;

        if (1 < playerName.Length && playerName.Length < 11)
        {
            playerObj.GetComponent<PlayerController>().ChangePlayerName(playerName);

            changeNameObj.SetActive(false);
        }
    }
}
