using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    CameraController mainCamera;
    [SerializeField] TMP_Text timeText;

    GameObject playerPrefab;
    GameObject playerObj;

    [SerializeField] GameObject mainCanvas; // 자꾸 화면 가려서
    [SerializeField] GameObject changeCharObj;
    [SerializeField] GameObject changeNameObj;
    [SerializeField] GameObject userListObj;

    public List<GameObject> userList;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main.GetComponent<CameraController>();

        int idx = PlayerPrefs.GetInt("PlayerCharIndex");
        playerPrefab = StartManager.Instance.charPrefabList[idx];

        mainCanvas.SetActive(true);
        changeCharObj.SetActive(false);
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

        List<Button> obj = new(changeCharObj.GetComponentsInChildren<Button>());
        for (int i = 0; i < obj.Count; i++)
        {
            obj[i].GetComponent<ChangeCharBtn>().myIndex = i;
        }
    }

    void UpdateTime()
    {
        // 현재 시간을 가져와서 텍스트로 변환
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // 텍스트 업데이트
        timeText.text = timeString;
    }

    public void ChangeCharStartBtn()
    {
        changeCharObj.SetActive(true);
    }

    public void ChangeCharCompleteBtn(int index)    // 캐릭터 변경을 선택 구현한거에서 변형하다보니 뭔가 이게 맞나.. 싶은느낌?
    {
        playerPrefab = StartManager.Instance.charPrefabList[index];
        Vector2 pos = playerObj.transform.position;
        Destroy(playerObj);
        playerObj = Instantiate(playerPrefab, pos, Quaternion.identity);
        mainCamera.playerTransform = playerObj.transform;

        changeCharObj.SetActive(false);
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
