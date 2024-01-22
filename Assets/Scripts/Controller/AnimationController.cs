using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AnimationController : Animations
{
    // StringToHash -> 문자열을 int값으로 변환
    // 변환 하는 이유 -> 문자열 비교연산이 시간을 많이 잡아 먹어서. 숫자 비교로 진행 하려고
    static readonly int IsWalking = Animator.StringToHash("IsWalking");
    static readonly int Slide = Animator.StringToHash("Slide");
    //static readonly int IsHit = Animator.StringToHash("IsHit");


    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnSlideEvent += Sliding;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
    }

    private void Sliding(Vector2 obj)
    {
        animator.SetTrigger(Slide);
    }
}
