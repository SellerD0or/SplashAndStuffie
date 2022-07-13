using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool _isAppear;
    [SerializeField] private float _waitTime;
    private float _currentColorness;
    [SerializeField] private float _smoothSpeed = 0.1f;

    public bool IsAppear { get => _isAppear; set => _isAppear = value; }
    private void Start() {
      Destroy(gameObject,_waitTime);
    }

    private void FixedUpdate() {
        if (_waitTime > _currentColorness)
        {
          _currentColorness *= Time.deltaTime * _smoothSpeed;
           UnityAction OnChangedColor = IsAppear ?(UnityAction) Disappear: (UnityAction)Appear;
           OnChangedColor?.Invoke();
        }
    }
    public void Disappear() => ChangeColor(_spriteRenderer.color,_color);
     public void Appear() => ChangeColor(_color,_spriteRenderer.color);
    private void ChangeColor(Color currentColor, Color color)
    {
      float speed = _waitTime - _currentColorness;
          _spriteRenderer.color = Color.Lerp(_spriteRenderer.color,_color, speed * _smoothSpeed * Time.deltaTime);
    }
}
