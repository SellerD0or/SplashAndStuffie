using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAkiAbilityFreeMode : AbilityFreeMode
{
     [SerializeField] private PlayerAkiTotem _playerAkiTotem;
     [SerializeField] private PlayerAkiAbilityFreeMode _playerAbility;
    public override void RemoveAbility()
    {
    }

    public override void UseAbility()
    {
        Debug.Log("COOOOOL");
      //  _playerAbility.CanUseAbility = true;
      Player.PlayerAnimatorFreeMode.UseAbility();
        Instantiate(_playerAkiTotem,transform.position,Quaternion.identity);
              CanUseAbility = false;

    }
}
