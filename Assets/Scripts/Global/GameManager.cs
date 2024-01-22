using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    GameObject playerPrefab;

    private void Awake()
    {
        Instance = this;

        int idx = PlayerPrefs.GetInt("PlayerCharIndex");
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // 이렇게 할거면 그냥 prefab을 가져오면 되는거 아닌가?
    }

    private void Start()
    {
        GameObject player = Instantiate(playerPrefab);
    }
}
