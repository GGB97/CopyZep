using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharBtn : MonoBehaviour
{
    // 캐릭터가 늘어난다면 이것도 프리팹화 해서 시작시 Instantiate 하면 될 것 같음
    public int myIndex;

    public void Selected()
    {
        StartManager.Instance.Init(myIndex);
    }
}
