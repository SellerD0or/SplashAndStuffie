using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEnemyText : MonoBehaviour
{
   [SerializeField] private Text _text;
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private float _speed = 30;
    public Text Text { get => _text; set => _text = value; }
    private void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
        _canvasGroup.alpha -= Time.deltaTime * 0.7f;
        if (_canvasGroup.alpha == 0)
        {
            Destroy(gameObject);
        }
    }
}
