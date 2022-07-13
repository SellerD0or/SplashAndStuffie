using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectialOpening : MonoBehaviour
{
  [SerializeField] private bool _isChooseNCharacter;
  private Settings _settings;
  private void Start() {
      _settings =FindObjectOfType<Settings>();
  }
  private void OnEnable() {
      if (_isChooseNCharacter)
      {
          _settings.Gogoscreen.OnCloseScene?.Invoke();
      }
  }
  private void OnDisable() {
     if (!_isChooseNCharacter)
      {
          _settings.Gogoscreen.OnLoadScene?.Invoke();
      }
  }
}
