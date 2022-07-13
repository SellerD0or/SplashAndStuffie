using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    // zatemeneine
    //pause => play
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _button;
    [SerializeField] private Animator _screen;
    [SerializeField] private CanvasGroup _panel;
    private  bool _isGameStopped;
    [SerializeField] private bool _isActive = false;
    private void Start() {
        _screen.gameObject.SetActive(true);
        _screen.SetTrigger("First");

    }
     private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         //  StopGame();
        }
    }
   public void StopGame()
   {
       _isGameStopped =! _isGameStopped;
       _button.sprite = _isGameStopped ? _sprites[0] : _sprites[1];
     //  if(_isActive)
       //{
         Time.timeScale = _isGameStopped ? 0 : 1;
      // }
       //EnemyWarriorMovement.CanMove  = _isGameStopped;
       _panel.alpha = _isGameStopped ? 1 : 0;
       _panel.blocksRaycasts =_isGameStopped;
        _screen.SetBool("Appear", _isGameStopped);
   }
}
