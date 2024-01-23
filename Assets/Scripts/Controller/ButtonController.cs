using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject changeNameObj;

    public void ChangeNameStart()
    {
        changeNameObj.SetActive(true);
    }
}
