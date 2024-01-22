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
        playerPrefab = StartManager.Instance.charPrefabList[idx]; // �̷��� �ҰŸ� �׳� prefab�� �������� �Ǵ°� �ƴѰ�?
    }

    private void Start()
    {
        GameObject player = Instantiate(playerPrefab);
    }
}
