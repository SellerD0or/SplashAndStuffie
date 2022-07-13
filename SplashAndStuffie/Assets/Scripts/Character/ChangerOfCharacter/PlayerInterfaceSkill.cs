using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaceSkill : MonoBehaviour
{
  [SerializeField] private CanvasGroup _canvasGroup;
     [SerializeField] private Text _text;
 [SerializeField] private Player  _player;
 private float _time;
 [SerializeField] private CanvasGroup _textCanvasGroup;
    public Text Text { get => _text; set => _text = value; }
    public Player Player { get => _player; set => _player = value; }
    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
    public bool IsDd2Skill { get => _isDd2Skill; set => _isDd2Skill = value; }
    [SerializeField] private Image _icon;
    private bool _isDd2Skill;
   [SerializeField] private Animator _skillAnimator;
     private void Start() {
       if(IsDd2Skill ==false)
       {
      StartCoroutine(CoolDown());
       }
    }
    private void Update() {
      if(Player != null && Player.IPlayerAttackable != null)
      {

      //  if(!_player.IPlayerAttackable.IsCoolDown)
       // {
          _time = _time + Time.deltaTime;
          if (_time > 1)
          {
            //if(Player.Ability.LastedTime > 0)
           // {
           // Player.Ability.LastedTime--;
          // Text.text = $"0 : {Player.IPlayerAttackable.ResultTime}";
           // }
           _time = 0;
          }
       // }
       }
 }
 public void GetPlayer(Player player)
 {
   Player =player;
   _icon.sprite = player.SemitransparentIconSkill;
   
 }
 private IEnumerator CoolDown()
 {
   Debug.LogError(Player.IPlayerAttackable.IsAttack + "CAN RELOAD!!!");
  if(Player.IPlayerAttackable.ResultTime > 0) 
   {
     if (_textCanvasGroup.blocksRaycasts== false)
     {
       _textCanvasGroup.alpha = 1;
          _skillAnimator.SetBool("Appear", false);
       _textCanvasGroup.blocksRaycasts = true;
     }
   Text.text = $"0 : {Player.IPlayerAttackable.ResultTime}";
   }
   else
   {
      if (_textCanvasGroup.blocksRaycasts)
     {
       _textCanvasGroup.alpha = 0;
          _skillAnimator.SetBool("Appear", true);
       _textCanvasGroup.blocksRaycasts = false;
     }
   }
   yield return new WaitForSeconds(1);
   StartCoroutine(CoolDown());
 }
    public void Show(Player player)
    { 
      Player = player;
       if (Text.gameObject.activeInHierarchy == false && player.Name != "Stuffie")
      {
       Text.gameObject.SetActive(true);
      }
      if (player.Name == "Stuffie")
      {
        Text.gameObject.SetActive(false);
        return;
      }
        // StopCoroutine(CoolDown());
      //  _isUsedAbility = player.Ability.IsCoolDown;
      // Player.Ability.LastedTime = Player.Ability.CoolDown
      if (player.IPlayerAttackable != null)
      {
      Text.text = $"0 : {Player.IPlayerAttackable.ResultTime}";
      }
        //if (Player.Ability.IsCoolDown)
        //{
       //     _canvasGroup.alpha = 0;

           //  StartCoroutine(CoolDown());
      //  }
      //  else
    //    {
          //  _canvasGroup.alpha = 1;
      //  }
       // StopAllCoroutines();
    }
}
