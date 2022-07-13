using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OutlineOfAbility : MonoBehaviour
{
     [SerializeField] private Player  _player;
   [SerializeField] private Image _icon;
   [SerializeField] private CanvasGroup _canvasGroup;

    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
    public Player Player { get => _player; set => _player = value; }

    public void GetPlayer(Player player)
 {
   Player =player;
   _icon.sprite = player.SemitransparentIconAbility;
  /* if(player.Ability == null)
   {
   player.Ability =  player.GetComponent<Ability>();
   }
   player.Ability.OnRemove += Remove;
   player.Ability.OnUploadAmount += UpdateAmount;*/
 }
 public void UpdateAmount()
 {
    // _icon.fillAmount = _player.Ability.CurrentTime / _player.Ability.CoolDown;
 }
 private void Remove()
 {
  //   _icon.fillAmount = 0;
 }
}
