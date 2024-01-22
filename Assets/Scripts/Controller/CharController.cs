using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // event 외부에서는 호출하지 못하게 막는다?
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<Vector2> OnSlideEvent;

    protected bool isSlide { get; set; }

    protected virtual void Awake()
    {

    }

    protected virtual void Update()
    {

    }

    // event는 외부클래스에서 invoke를 실행 시킬수 없기 때문에 실행을 시킬수 있는 함수를 만들어 둔 것 같음.
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallSlideEvent(Vector2 direction)
    {
        OnSlideEvent?.Invoke(direction);
    }
}
