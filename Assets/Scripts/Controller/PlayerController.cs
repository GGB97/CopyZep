using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Charactor_Info
{
    TMP_Text _nameText;

    [SerializeField] GameObject dialogueCanvas;
    NPC_Controller lastTriggerNPC;

    private void Awake()
    {
        _nameText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();

        dialogueCanvas.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            dialogueCanvas.transform.GetChild(1).gameObject.SetActive(true);
            lastTriggerNPC = collision.gameObject.GetComponent<NPC_Controller>();

            SetActveDialogueOn(0);
            SetActveDialogueOff(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            dialogueCanvas.SetActive(false);
        }
    }

    public void DialogueBtn()
    {
        SetActveDialogueOff(0);
        SetActveDialogueOn(1);

        TMP_Text dialogueText = dialogueCanvas.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>();
        dialogueText.text = lastTriggerNPC.dialogue;

        //Debug.Log(lastTriggerNPC.dialogue);
    }

    public void CloseDialogueBtn()
    {
        dialogueCanvas.SetActive(false);
    }

    void SetActveDialogueOn(int childIndex)
    {
        dialogueCanvas.SetActive(true);
        dialogueCanvas.transform.GetChild(childIndex).gameObject.SetActive(true);
    }

    void SetActveDialogueOff(int childIndex)
    {
        dialogueCanvas.SetActive(true);
        dialogueCanvas.transform.GetChild(childIndex).gameObject.SetActive(false);
    }
}
