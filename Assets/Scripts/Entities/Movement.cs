using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    CharController _controller;

    Vector2 _moventDirection = Vector2.zero;
    Rigidbody2D _rigidbody;

    float knockbackDuration = 0; // �뽬�� �ٲٸ� �ɵ�?

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
            knockbackDuration -= Time.fixedDeltaTime; // Time.deltaTime -> �̰� Update ������ ���
        }                                             // FixedUpdate ������ Time.fixedDeltaTime ���
    }

    void Move(Vector2 direction)
    {
        _moventDirection = direction;
    }

    void ApplyMovent(Vector2 direction)
    {
        direction = direction * 5f; // �ӵ�

        _rigidbody.velocity = direction;
    }
}
