using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰� ScriptableObjects ���� �غ��� ������ �ð���... �̹��� �ʹ� �����ѵ� �մϴ�...��
public class PlayerInfo 
{
    public string Name { get; set; }

    public PlayerInfo(string name)
    {
        this.Name = name;
    }
}
