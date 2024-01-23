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
    [SerializeField] GameObject userListObj;

    public List<GameObject> userList;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main.GetComponent<CameraController>();

        int idx = PlayerPrefs.GetInt("PlayerCharIndex");
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // 이렇게 할거면 그냥 prefab을 가져오면 되는거 아닌가?

        changeNameObj.SetActive(false);
        userListObj.SetActive(false);
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
    public void ChangeNameStartBtn()
    {
        changeNameObj.SetActive(true);
    }

    public void ChangeNameCompleteBtn()
    {
        string playerName = changeNameObj.GetComponentInChildren<TMP_InputField>().text;

        if (1 < playerName.Length && playerName.Length < 11)
        {
            playerObj.GetComponent<PlayerController>().ChangePlayerName(playerName);

            changeNameObj.SetActive(false);
        }
    }

    public void ShowUserListBtn()
    {
        if(userListObj.activeSelf)
            userListObj.SetActive(false);
        else
        {
            userListObj.SetActive(true);

            userList = SearchToLayer("User");   // "User" Layer를 가진 부모객체 검색 후 리스트에 넣기

            if(userList != null)
            {
                TMP_Text userListText =  userListObj.transform.GetChild(2).GetComponent<TMP_Text>();
                userListText.text = string.Empty; // 한번 비우기
                foreach (var item in userList)
                {
                    // Charactor_Info 에서 이름 가져와서 추가
                    userListText.text += item.GetComponent<Charactor_Info>().getName + "\n"; 
                }
            }
        }
    }

    List<GameObject> SearchToLayer(string layerName)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        int userLayerMask = 1 << LayerMask.NameToLayer(layerName);

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            int objectLayer = 1 << obj.layer; // 오브젝트의 레이어를 가져옴

            // "User" 레이어와 일치하는지 비트 연산으로 검사
            if ((objectLayer & userLayerMask) != 0 && obj.transform.parent == null)
            {
                //Debug.Log(obj.name);
                gameObjects.Add(obj);
            }
        }

        return gameObjects;
    }
}
