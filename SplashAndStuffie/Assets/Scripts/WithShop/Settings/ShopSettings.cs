using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShopSettings : MonoBehaviour
{
    public event UnityAction OnPlayGame;
    [SerializeField] private CanvasGroup _panel;
    [SerializeField] private CanvasGroup _buttonSettings;
    private  bool _isGameStopped = false;
    [SerializeField] private bool _isActive = false;
     private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           StopGame();
        }
    }
   public void StopGame()
   {
       if(_isActive)
       {
       Time.timeScale = _isGameStopped ? 1:0;
       }
       _isGameStopped =! _isGameStopped;
       if (_isGameStopped == false)
       {
        OnPlayGame?.Invoke();
       }
       _panel.alpha = _isGameStopped ? 1 : 0;
       _panel.blocksRaycasts =_isGameStopped;
       _buttonSettings.alpha = _isGameStopped ? 0 : 1;
       _buttonSettings.blocksRaycasts =!_isGameStopped;
   }
}
