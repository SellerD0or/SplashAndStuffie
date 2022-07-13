using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelAbilityFreeMode : AbilityFreeMode
{
    [SerializeField] private PlayerAxelAnimatorFreeMode _playerAnimator;
     [SerializeField] private PlayerAxelRocketFreeMode _rocket;
     [SerializeField] private PlayerAxelTargetFreeMode _target;
     private PlayerAxelTargetFreeMode _currentTarget;
     [SerializeField] private float _additionHigh = 7;
     private void Start() {
         _currentTarget = Instantiate(_target,transform.position,Quaternion.identity);
         _currentTarget.gameObject.SetActive(false);
     }
    public override void RemoveAbility()
    {
        _currentTarget.gameObject.SetActive(false);
    }

    public override void UseAbility()
    {
      //  Debug.LogError("Axel ability");
      //  CanUseAbility = true;
        _currentTarget.gameObject.SetActive(true);
        _playerAnimator.UseAbility();
        _currentTarget.SetPosition( Player.ClosestEnemy.transform.position);
        
       PlayerAxelRocketFreeMode rocket =  Instantiate(_rocket,_currentTarget.transform.position + new Vector3(0,_additionHigh,0),Quaternion.identity);
       rocket.PositionYForStop = Player.ClosestEnemy.transform.position.y;
       rocket.PlayerInformation = Player;
    }
}
