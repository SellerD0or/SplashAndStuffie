using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBoard : MonoBehaviour
{
    private Animator _animator;
    private bool _disappered;
  private void Start() {
      _animator = GetComponent<Animator>();
      Invoke(nameof(Disappear),1);
      Destroy(gameObject,8);
  }
  private void Disappear() => _disappered = true;
  private void Update() {
      if (_disappered)
      {
          _animator.SetBool("Disappeared",true);
      }
  }
}
