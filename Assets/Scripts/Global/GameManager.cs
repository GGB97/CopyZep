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

    [SerializeField] GameObject mainCanvas; // �ڲ� ȭ�� ������
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
        // ���� �ð��� �����ͼ� �ؽ�Ʈ�� ��ȯ
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("HH:mm");

        // �ؽ�Ʈ ������Ʈ
        timeText.text = timeString;
    }

    public void ChangeCharStartBtn()
    {
        changeCharObj.SetActive(true);
    }

    public void ChangeCharCompleteBtn(int index)    // ĳ���� ������ ���� �����Ѱſ��� �����ϴٺ��� ���� �̰� �³�.. ��������?
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

            userList = SearchToLayer("User");   // "User" Layer�� ���� �θ�ü �˻� �� ����Ʈ�� �ֱ�

            if(userList != null)
            {
                TMP_Text userListText =  userListObj.transform.GetChild(2).GetComponent<TMP_Text>();
                userListText.text = string.Empty; // �ѹ� ����
                foreach (var item in userList)
                {
                    // Charactor_Info ���� �̸� �����ͼ� �߰�
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
            int objectLayer = 1 << obj.layer; // ������Ʈ�� ���̾ ������

            // "User" ���̾�� ��ġ�ϴ��� ��Ʈ �������� �˻�
            if ((objectLayer & userLayerMask) != 0 && obj.transform.parent == null)
            {
                //Debug.Log(obj.name);
                gameObjects.Add(obj);
            }
        }

        return gameObjects;
    }
}
