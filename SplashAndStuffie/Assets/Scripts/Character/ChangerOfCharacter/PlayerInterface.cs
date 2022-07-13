using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
      [SerializeField] private Transform _topBoardPosition;
  [SerializeField] private Transform _bottomBoardPosition;
    [SerializeField]private Transform _spetialPosition;
    [SerializeField] private Text _text;
    [SerializeField] private GetterPlayer _getterPlayer;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _iconSkill;
    [SerializeField] private Image _iconAbility;
    [SerializeField] private PlayerAbilityInterface _playerAbilityInterface;
    [SerializeField] private List< PlayerAbilityInterface> _playerAbilityInterfaces;
    [SerializeField] private Animator _ability;
    [SerializeField] private CanvasGroup _canvasGroupAbility;
    [SerializeField] private CanvasGroup _canvasGroupSkill;
    [SerializeField] private PlayerInterfaceSkill _playerInterfaceSlill;
    [SerializeField] private Animator _skill;

    public List<PlayerAbilityInterface> PlayerAbilityInterfaces { get => _playerAbilityInterfaces; set => _playerAbilityInterfaces = value; }
    public GetterPlayer GetterPlayer { get => _getterPlayer; set => _getterPlayer = value; }
    public PlayerAbilityInterface PlayerAbilityInterface { get => _playerAbilityInterface; set => _playerAbilityInterface = value; }
    public PlayerInterfaceSkill PlayerInterfaceSlill { get => _playerInterfaceSlill; set => _playerInterfaceSlill = value; }
    public Animator Skill { get => _skill; set => _skill = value; }
    public Transform SpetialPosition { get => _spetialPosition; set => _spetialPosition = value; }
    public Transform TopBoardPosition { get => _topBoardPosition; set => _topBoardPosition = value; }
    public Transform BottomBoardPosition { get => _bottomBoardPosition; set => _bottomBoardPosition = value; }

    private void OnEnable() {
        GetterPlayer.OnDestroy += Show;
    }
   public void Show()
   {
      // if(GetterPlayer.CreatedPlayer.PlayerHealth.HaveEventsOnApplyDamage(UpdateText))
     //  {
      //     GetterPlayer.CreatedPlayer.PlayerHealth.ApplyDamage -= UpdateText;
     //  }
       // GetterPlayer.CreatedPlayer.PlayerHealth.ApplyDamage -= UpdateText;
       UpdateText();
         _iconAbility.sprite = GetterPlayer.CreatedPlayer.SemitransparentIconAbility;
        _iconSkill.sprite = GetterPlayer.CreatedPlayer.SemitransparentIconSkill;
       _icon.sprite = GetterPlayer.CreatedPlayer.BarIcon;
       PlayerAbilityInterface.Show(GetterPlayer.CreatedPlayer);
     //  PlayerInterfaceSlill.Show(GetterPlayer.CreatedPlayer);
       if (GetterPlayer.CreatedPlayer.Ability.IsCoolDown)
       {
               DisactiveAbility();
        //    ActiveAbility();
       }
       else
       {
           ActiveAbility();
       }
//       Debug.Log(GetterPlayer.CreatedPlayer.IPlayerAttackable.IsReloading + " IS RELOADING");
       if (GetterPlayer.CreatedPlayer.IPlayerAttackable.IsReloading)
       {
           DisactiveSkill();
       }
       else
       {
           ActiveSkill();
       }
       
   }
   public void ActiveAbility()
   {

       _canvasGroupAbility.alpha =1;
      PlayerAbilityInterface.Show(_getterPlayer.CreatedPlayer);
      // _ability.SetBool("Appear", false);
   }
   public void DisactiveAbility()
   {
      _canvasGroupAbility.alpha = 0;
     //  _ability.SetBool("Appear", true);
   }
   public void ActiveSkill()
   {
       _canvasGroupSkill.alpha = 1;
      if( _getterPlayer.CreatedPlayer is Dd2)
       {
       return;
       } 
       Skill.SetBool("Appear", false);
   }
   public void DisactiveSkill()
   {
       _canvasGroupSkill.alpha = 0;
          if( _getterPlayer.CreatedPlayer is Dd2)
       {
       return;
       } 
       Skill.SetBool("Appear", true);
   }
   public void UpdateText() =>  _text.text = GetterPlayer.CreatedPlayer.PlayerHealth.Health + " / " + GetterPlayer.CreatedPlayer.PlayerHealth.MaxHealth;
   private void Update() {
    //   UpdateText();
   }
}
