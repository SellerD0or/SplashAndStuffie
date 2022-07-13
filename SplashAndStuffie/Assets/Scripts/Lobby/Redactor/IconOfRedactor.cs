using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IconOfRedactor : MonoBehaviour
{
  [SerializeField] private RedactorButton _redactor;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _waitTime;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _speed = 2f;
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    private bool _moveForvard;
    private bool _moveBack;
    private IEnumerator CoolDown(bool _isAppeared)
    {
        yield return new WaitForSeconds(WaitTime);
     //  UnityAction OnEvent = _isAppeared ? (UnityAction) MoveBack : (UnityAction) MoveForward;
     //  OnEvent?.Invoke();
        //Debug.Log("yeyey");
         _animator.SetBool("Appearing",_isAppeared);
    }
    public void Appear(bool _isAppeared)
    {
     // _redactor.ChangeStateOfRedactorButton(_isAppeared);
    //  StartCoroutine(CoolDown(_isAppeared));
        _animator.SetBool("Appearing",_isAppeared);
    }
    private void MoveForward()=> _moveForvard = true;
    private void MoveBack() => _moveBack = true;
    private void Update() {
      if (_moveBack)
      {
           if (_startPosition.y - transform.position.y > 1)
          {
              transform.position = Vector3.MoveTowards(_endPosition,_startPosition,_speed * Time.deltaTime);
          }
          else
          {
              _moveBack = false;
          }
      }
      if (_moveForvard)
      {
          if (transform.position.y - _endPosition.y > 1)
          {
              transform.position = Vector3.MoveTowards(_startPosition,_endPosition,_speed * Time.deltaTime);
          }
             else
          {
              _moveForvard = false;
          }
      }
    }
  public void ChangeStateOfIconOfRedactor(bool _isAppeared)
  {
    Debug.Log("coolas");
     StartCoroutine(CoolDown(_isAppeared));
  }
}
