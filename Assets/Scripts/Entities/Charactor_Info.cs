using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor_Info : MonoBehaviour
{
    [SerializeField] protected string name;

    public Charactor_Info()
    {

    }

    public Charactor_Info(string name)
    {
        this.name = name;
    }

    public string getName
    {
        get { return name; }
    }
}
