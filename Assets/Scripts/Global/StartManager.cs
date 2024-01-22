using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance;
    [SerializeField] TMP_InputField _inputField;
    public List<GameObject> charPrefabList;

    [SerializeField] GameObject SelectObj;
    [SerializeField] GameObject SelectedObj;

    public GameObject selectedImg;


    int selectedIdx;


    private void Awake()
    {
        Instance = this;

        Init();
    }

    private void Start()
    {
        List<Button> obj = new (SelectObj.GetComponentsInChildren<Button>());
        for(int i = 0; i < obj.Count; i++)
        {
            obj[i].GetComponent<SelectCharBtn>().myIndex = i;
        }
    }

    public void Init(int idx = 0)
    {
        selectedIdx = idx;
        Sprite sprite = charPrefabList[idx].GetComponentInChildren<SpriteRenderer>().sprite;
        selectedImg.GetComponent<Image>().sprite = sprite;

        SelectedObj.SetActive(true);
        SelectObj.SetActive(false);
    }

    public void Join()
    {
        string str = _inputField.text;
        if (1 < str.Length && str.Length < 11)
        {
            PlayerPrefs.SetString("PlayerName", _inputField.text);
            PlayerPrefs.SetInt("PlayerCharIndex", selectedIdx);

            SceneManager.LoadScene("MainScene");
        }
    }

    public void SelectStart()
    {
        SelectedObj.SetActive(false);
        SelectObj.SetActive(true);
    }
}
