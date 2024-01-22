using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이걸 ScriptableObjects 으로 해볼까 했지만 시간이... 이번주 너무 빡빡한듯 합니다...ㅜ
public class PlayerInfo 
{
    public string Name { get; set; }

    public PlayerInfo(string name)
    {
        this.Name = name;
    }
}
