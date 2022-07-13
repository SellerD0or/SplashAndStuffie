using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactInfo : MonoBehaviour
{
  [SerializeField] private Sprite _sprite;
  [SerializeField] private SpriteRenderer _spriteRenderer;

    public Sprite Sprite { get => _sprite; set => _sprite = value; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
}
