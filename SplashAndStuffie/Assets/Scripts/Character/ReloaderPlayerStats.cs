using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloaderPlayerStats : MonoBehaviour
{
   [SerializeField]   private SelecterCharacter _selecterCharacter;
    [SerializeField] private PlayerInterface _playerInterface;
    private Player _currentPlayer;
    private float _time =0;
    private float _time2 =0;

    public SelecterCharacter SelecterCharacter { get => _selecterCharacter; set => _selecterCharacter = value; }
    public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }

    private void Start() {
      if (_playerInterface == null)
      {
        _playerInterface = FindObjectOfType<PlayerInterface>();
      }
      if(SelecterCharacter.CurrentCharacters.Count < 4)
      {
        CurrentPlayer = SelecterCharacter.CurrentCharacters[2];
        SelecterCharacter.OnSelect += OnChangeCharacter;
      }
    }
    private void OnChangeCharacter(int numberOfCharacter)
    {
      CurrentPlayer = SelecterCharacter.CurrentCharacters[numberOfCharacter];
    }
    private void Update() 
    {
        if(SelecterCharacter.CurrentCharacters.Count > 0)
      Reload();
    }
    private void Reload()
    {
     /* _time2 += Time.deltaTime;
      if (_time2 >= 11)
      {
        for (int i = 0; i < _selecterCharacter.CurrentCharacters.Count; i++)
            {
              //  if (_selecterCharacter.CurrentCharacters[i] is MummyHat)
              // {
               //     continue;
              //  }
              
                if (_selecterCharacter.CurrentCharacters[i].Ability.IsReloadByTime == false)
                {
                 _selecterCharacter.CurrentCharacters[i].Ability.UpdateAmount(1);
                }
            }
        _time2 =0;
      }*/
          _time += Time.deltaTime;
        if (_time >= 1)
        {
           for (int i = 0; i < SelecterCharacter.CurrentCharacters.Count; i++)
            {
              if (SelecterCharacter.CurrentCharacters[i].Ability.IsReloadByTime == false && SelecterCharacter.CurrentCharacters[i].Ability.IsAbilityRemoved == false)
                {
                SelecterCharacter.CurrentCharacters[i].Ability.StartReload();
                }
                if (SelecterCharacter.CurrentCharacters[i].IPlayerAttackable.IsReloading == false)
                {
                 SelecterCharacter.CurrentCharacters[i].IPlayerAttackable.Reload();
                }
            }
            int index =SelecterCharacter.CurrentCharacters.IndexOf(CurrentPlayer);
           // _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {SelecterCharacter.CurrentCharacters[index].Ability.LastedTime}";
          if(SelecterCharacter.CurrentCharacters[index].Ability.IsCoolDown == false)
           {
             SelecterCharacter.CurrentCharacters[index].Ability.CurrentTime++;
             if (SelecterCharacter.CurrentCharacters[index].Ability.CurrentTime > SelecterCharacter.CurrentCharacters[index].Ability.TimeForRemovingAbility)
             {
               SelecterCharacter.CurrentCharacters[index].Ability.RemoveAbility();
               SelecterCharacter.CurrentCharacters[index].Ability.CurrentTime = 0;
               SelecterCharacter.CurrentCharacters[index].Ability.IsCoolDown = true;
             } 
          //  _playerInterface.PlayerInterfaceSlill.Text.text = $"0 : {_selecterCharacter.CurrentCharacters[index].IPlayerAttackable.ResultTime}";
              }
            _time =0;
        }
    }
}
