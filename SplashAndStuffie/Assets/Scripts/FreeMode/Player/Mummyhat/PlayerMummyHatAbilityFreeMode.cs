using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMummyHatAbilityFreeMode : AbilityFreeMode
{
   [SerializeField] private PlayerMummyHatPointFreeMode _playerMummyHatPoint;
   private bool _isAbilityUsed;
   [SerializeField] private float _speed = 1;
   [SerializeField] private float _range = 0.5f;
   private bool _isEffectUsing;
    public bool IsAbilityUsed { get => _isAbilityUsed; set => _isAbilityUsed = value; }

    private void Start() {
      // _playerMummyHatPoint.PlayerInformation = Player;
   }
    public override void RemoveAbility()
    {
        IsAbilityUsed = false;
              Player.PlayerAnimatorFreeMode.ArmatureComponent.sortingOrder = 11;
              _isEffectUsing = true;
            EnemyInformationFreeMode enemy=   Player.PlaceRow.Enemies.Find(e=> e.IsByPlayerControl == true);
            if (enemy != null)
            {
                enemy.IsByPlayerControl = false;
            }
       // _playerMummyHatPoint.Collider.enabled = false;
    }

    public override void UseAbility()
    {    
        if(Player.ClosestEnemy == null)
        {
            Player.FindClosestEnemy();
        }
        if (Player.ClosestEnemy != null)
        {
     //   Player.PlayerAnimatorFreeMode.Run();
      _playerMummyHatPoint.Collider.enabled = false;
      Player.PlayerAnimatorFreeMode.ArmatureComponent.sortingOrder = -100;
       IsAbilityUsed = true;
        }
      // Player.PlayerAnimatorFreeMode.Attack();
    }
    private void Update() {
       if(IsAbilityUsed)
       {
        transform.position = Vector3.MoveTowards(transform.position, Player.ClosestEnemy.transform.position, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Player.ClosestEnemy.transform.position) < _range && _isEffectUsing == false)
        {
            _isEffectUsing = true;
        }
       }
    }
}
