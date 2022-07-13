using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerState : MonoBehaviour
{
    private TypeOfAnimation _typeOfAnimation;
    [SerializeField] private Enemy _enemy;
    public bool IsTimeStopped { get; set; }
    private void OnEnable() {
        IsTimeStopped = false;
    }
    private void Start() {
        _enemy = GetComponent<Enemy>();
    }
    private void Update() {
        if(!IsTimeStopped)
        {
        if (_enemy.CanAttack() && !_enemy.CanStop())
        {
            _typeOfAnimation = TypeOfAnimation.Shoot;
        }
        else if (!_enemy.CanAttack() && !_enemy.CanStop())
        {
         _typeOfAnimation = TypeOfAnimation.Run;   
        }
        else
        {
            _typeOfAnimation = TypeOfAnimation.Idle;
        }
        
      switch (_typeOfAnimation)
      {
          case TypeOfAnimation.Idle:
          
          _enemy.IEnemyAnimator.PlayStay();
          break;   
           case TypeOfAnimation.Run:
          _enemy.IEnemyMovement.Move(_enemy);
          _enemy.IEnemyAnimator.PlayMovement();
          break; 
           case TypeOfAnimation.Shoot:
           _enemy.IEnemyAttackable.Attack(_enemy.GetterPlayer.CreatedPlayer, _enemy);
          _enemy.IEnemyAnimator.PlayAttack();
          break;  
      }  
        }
    }

}
