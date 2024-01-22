using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    CharController _controller;

    Vector2 _moventDirection = Vector2.zero;
    Rigidbody2D _rigidbody;

    bool _isSliding;
    float _slidingDuration;

    private void Awake()
    {
        _controller = GetComponent<CharController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnSlideEvent += Sliding;
        SlidingInit();
    }

    private void FixedUpdate()
    {
        ApplyMovent(_moventDirection);

        if (_isSliding)
        {
            _slidingDuration -= Time.fixedDeltaTime;

            if(_slidingDuration < 0)
            {
                SlidingInit();
            }
        }
    }

    void SlidingInit()
    {
        _moventDirection = Vector2.zero;
        _isSliding = false;
        _slidingDuration = 0.6f;
    }

    void Move(Vector2 direction)
    {
        if(!_isSliding)
            _moventDirection = direction;
    }
    void Sliding(Vector2 direction)
    {
        _moventDirection = direction * 2f;
        _isSliding = true;
    }
    void ApplyMovent(Vector2 direction)
    {
        direction = direction * 5f; // ¼Óµµ

        _rigidbody.velocity = direction;
    }
}
