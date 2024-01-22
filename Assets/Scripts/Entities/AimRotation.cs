using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] SpriteRenderer charRenderer;

    CharController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDiredction)
    {
        RotateArm(newAimDiredction);
    }

    void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        charRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
