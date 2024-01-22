using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputField;

    public void Join()
    {
        string str = _inputField.text;
        if (1 < str.Length && str.Length < 11)
        {
            PlayerPrefs.SetString("PlayerName", _inputField.text);
            SceneManager.LoadScene("MainScene");
        }
    }

}
