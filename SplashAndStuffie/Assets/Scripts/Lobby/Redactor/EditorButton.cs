using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorButton : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  [SerializeField] private  List<IconOfRedactor> _iconOfRedactors;  
  private int _countOfRedactors;
  private bool _isAppeared;
  private bool _canMove;
  private float _currentTime =0;
  public void ChangeStateOfEditorButton(bool isAppeared)
  {
    _countOfRedactors = 0;
      _animator.SetBool("Appearing",isAppeared);
      _isAppeared = isAppeared;
      _canMove =_isAppeared;
     for(int i = 0; i < _iconOfRedactors.Count; i++)
     {
             _iconOfRedactors[i].ChangeStateOfIconOfRedactor(_isAppeared);
      }
      StartCoroutine(ChangeStateOfIconOfRedactor(_iconOfRedactors[_countOfRedactors]));
  }
/*  private void Update() {
    if(_isAppeared && _canMove)
    {
    
    _currentTime += Time.deltaTime;
    if (_currentTime >= 1)
    {
       _iconOfRedactors[_countOfRedactors].Appear(_isAppeared);
   _countOfRedactors ++;
     if (_countOfRedactors >= _iconOfRedactors.Count)
    {
      _canMove = false;
    }
    Debug.Log("Pup");
      _currentTime = 0;
    }
    }
  }*/
  private IEnumerator ChangeStateOfIconOfRedactor(IconOfRedactor iconOfRedactor)
  {
   _iconOfRedactors[_countOfRedactors].Appear(_isAppeared);
   _countOfRedactors ++;
    yield return new WaitForSeconds(_iconOfRedactors[_countOfRedactors].WaitTime);
   
    if (_countOfRedactors <= _iconOfRedactors.Count)
    {
      Debug.Log(iconOfRedactor.WaitTime + " so");
      
       
        StartCoroutine(ChangeStateOfIconOfRedactor(_iconOfRedactors[_countOfRedactors]));

    }
  }
}
