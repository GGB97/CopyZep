using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInfo _info;
    TMP_Text _nameText;

    void Start()
    {
        string name = PlayerPrefs.GetString("PlayerName");
        _info = new PlayerInfo(name);
        _nameText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();

        _nameText.text = _info.Name;

        Debug.Log("Player Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
