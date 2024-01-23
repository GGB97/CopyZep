using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Controller : Charactor_Info
{
    TMP_Text _nameText;

    public string dialogue;
    private void Awake()
    {
        _nameText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();

        dialogue = "æ»≥Á«œººø‰.";
    }

    void Start()
    {
        _nameText.text = this.name;
    }


}
