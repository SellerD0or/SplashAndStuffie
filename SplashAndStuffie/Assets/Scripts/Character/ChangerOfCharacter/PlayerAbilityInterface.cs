using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityInterface : MonoBehaviour
{
  [SerializeField] private Image _iconOfActivityOfAbility;
  [SerializeField] private Text _text;
 [SerializeField] private Player  _player;
  private Ability _ability;
  private float _time;
  private float _currentTime;
    public Player Player { get => _player; set => _player = value; }
    public Text Text { get => _text; set => _text = value; }

    private bool _isUsedAbility;
    [SerializeField] private CanvasGroup _canvasGroup;
    private Player _lastPlayer;
    public void Show(Player player)
    { 
      Player = player;
    // if (_lastPlayer != null)
    // {
   //    _lastPlayer.Ability.OnFull -= ActiveIcon;
    // }
    // Player.Ability.OnFull += ActiveIcon;
        // StopCoroutine(CoolDown());
      //  _isUsedAbility = player.Ability.IsCoolDown;
      // Player.Ability.LastedTime = Player.Ability.CoolDown;
     // _iconOfActivityOfAbility.gameObject.SetActive(false);
     // Text.text = $"0 : {Player.Ability.LastedTime}";
        if (Player.Ability.IsCoolDown)
        {
            _canvasGroup.alpha = 0;

           //  StartCoroutine(CoolDown());
        }
        else
        {
            _canvasGroup.alpha = 1;
        }
       // _lastPlayer = player;
       // StopAllCoroutines();
    }
    private void ActiveIcon() => _iconOfActivityOfAbility.gameObject.SetActive(true);
    private void Update() {
      if(Player != null)
      {
        if(!Player.Ability.IsCoolDown)
        {
          _time = _time + Time.deltaTime;
          if (_time > 1)
          {
            //if(Player.Ability.LastedTime > 0)
           // {
           // Player.Ability.LastedTime--;
           Text.text = $"0 : {Player.Ability.LastedTime}";
           // }
           _time = 0;
          }
      
       }
      }
    }
    public void Show(Ability ability)
  {
    //  _ability = ability;
      //_ability.Time = ability.CoolDown;
    //  _time = _ability.CoolDown;
      //_ti = _time;
     //StopCoroutine(CoolDown());
      if(!ability.IsCoolDown)
    {
     // StartCoroutine(CoolDown());
    }
    else
    {
         
    }
  }
  private IEnumerator CoolDown()
  {
      yield return new WaitForSeconds(1);
      _ability.LastedTime--;
      Text.text = $"0 : {_ability.LastedTime}";
      if (_ability.LastedTime > 0)
      {
          StartCoroutine(CoolDown());
      }
  }
   
}
