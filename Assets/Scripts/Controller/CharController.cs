using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // event �ܺο����� ȣ������ ���ϰ� ���´�?
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnDashEvent;

    float _timeSinceLastDash = float.MaxValue;

    protected bool isDash { get; set; }

    protected virtual void Awake()
    {
        HandleAttackDelay();
    }
    void HandleAttackDelay()
    {
        //if (_timeSinceLastDash <= Stats.CurrentStats.attackSO.delay)
        //{
        //    _timeSinceLastDash += Time.deltaTime;
        //}
        //if (isDash && _timeSinceLastDash > Stats.CurrentStats.attackSO.delay)
        //{
        //    _timeSinceLastDash = 0f;
        //    CallAttackEvent(Stats.CurrentStats.attackSO);
        //}
    }

    // event�� �ܺ�Ŭ�������� invoke�� ���� ��ų�� ���� ������ ������ ��ų�� �ִ� �Լ��� ����� �� �� ����.
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent()
    {
        OnDashEvent?.Invoke();
    }
}
