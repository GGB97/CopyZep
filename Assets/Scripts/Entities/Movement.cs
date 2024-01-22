using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    CharController _controller;

    Vector2 _moventDirection = Vector2.zero;
    Rigidbody2D _rigidbody;

    float knockbackDuration = 0; // 대쉬로 바꾸면 될듯?

    private void Awake()
    {
        _controller = GetComponent<CharController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovent(_moventDirection);
        if (knockbackDuration > 0)
        {
            knockbackDuration -= Time.fixedDeltaTime; // Time.deltaTime -> 이건 Update 문에서 사용
        }                                             // FixedUpdate 에서는 Time.fixedDeltaTime 사용
    }

    void Move(Vector2 direction)
    {
        _moventDirection = direction;
    }

    void ApplyMovent(Vector2 direction)
    {
        direction = direction * 5f; // 속도

        _rigidbody.velocity = direction;
    }
}
