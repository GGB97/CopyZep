using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharBtn : MonoBehaviour
{
    // ĳ���Ͱ� �þ�ٸ� �̰͵� ������ȭ �ؼ� ���۽� Instantiate �ϸ� �� �� ����
    public int myIndex;

    public void Selected()
    {
        StartManager.Instance.Init(myIndex);
    }
    public void Change()
    {
        GameManager.Instance.ChangeCharCompleteBtn(myIndex);
    }
}
