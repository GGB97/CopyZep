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
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // �̷��� �ҰŸ� �׳� prefab�� �������� �Ǵ°� �ƴѰ�?

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
        // ���� �ð��� �����ͼ� �ؽ�Ʈ�� ��ȯ
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // �ؽ�Ʈ ������Ʈ
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
