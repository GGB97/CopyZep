using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputController : CharController
{
    Camera _camera;
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // 정규화 하는 이유 -> wa/wd 와 같은 입력시 벡터값이 높아져서 속도가 달라짐.
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        // 벡터간의  A - B 를 하면 B->A의 방향벡터가 나옴 그 값을 정규화

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

    // 슬라이드 부분이 원하는 방향과 좀 다르게 어거지로 구현 해놓은거라..
    // 원하는 방식은 슬라이드 할때는 move 이동을 못하고 마우스 커서 방향으로 일정시간 가속
    // 그 후 방향키를 누르고 있으면 그대로 다시 move <- 이 부분에서 Movement.SlidingInit 이 함수로 vector.zero를 넣어주지 않으면
    // 슬라이딩의 속도가 계속 유지되는 현상이 있습니다.
    // 이걸 어떤 방식으로 고쳐야 할까요?
    public void OnSlide(InputValue value) 
    {
        // 마우스 위치를 Vector2 값으로 가져오기
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePos);
        Vector2 direction = (worldPos - (Vector2)transform.position).normalized;
        
        CallSlideEvent(direction);
    }
}
