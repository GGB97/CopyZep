using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharBtn : MonoBehaviour
{
    // ĳ���Ͱ� �þ�ٸ� �̰͵� ������ȭ �ؼ� ���۽� Instantiate �ϸ� �� �� ����
    public int myIndex;

    public void Selected()
    {
        StartManager.Instance.Init(myIndex);
    }
}
