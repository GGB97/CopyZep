using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Charactor_Info
{
    TMP_Text _nameText;

    private void Awake()
    {
        _nameText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        string name = PlayerPrefs.GetString("PlayerName");
        this.name = name;

        _nameText.text = this.name;
    }

    public void ChangePlayerName(string str)
    {
        this.name = str;
        _nameText.text = this.name;
        PlayerPrefs.SetString("PlayerName", this.name);
    }
}
