using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedGameSlotWindow : MonoBehaviour
{
    [SerializeField] private Animator _animator;
  [SerializeField]  private CanvasGroup _canvasGroup;
  public event UnityAction OnChoose;
  public event UnityAction OnExit;
  public void Enter()
  {
        if (_canvasGroup.alpha ==0)
      {
          _canvasGroup.alpha = 1;
      }
      _animator.SetBool("Appeared",true);
      _canvasGroup.blocksRaycasts = true;
  }
  public void Choose()
  {
    
      OnChoose?.Invoke();
      Close();
  }
  private void Close()
  {
      _animator.SetBool("Appeared",false);
      _canvasGroup.blocksRaycasts = false;
  }
  public void Exit()
  {
      Close();
      OnExit?.Invoke();   
  }
}
