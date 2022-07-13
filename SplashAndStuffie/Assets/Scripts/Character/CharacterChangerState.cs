using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangerState : MonoBehaviour
{
        private TypeOfCharacterState _typeOfCharacterState;
    [SerializeField] private Player _player;
    [SerializeField] private bool _isDD1;
    private void Start() {
        _player = GetComponent<Player>();
    }
    private void Update() {
        if(!_isDD1)
        {
     //   if (_player.CanAttack() && !_player.CanStop())
     //   {
       //     _typeOfCharacterState = TypeOfCharacterState.Attack;
        //}
        Debug.LogError(_player.IsAttack() + " Attack!");
         if(_player.IsAttack())
        {
           Debug.Log("IsAttack sas");
//          Debug.LogError(_player.IsAttack()+ " " + _player.IsMove());
            _typeOfCharacterState = TypeOfCharacterState.Attack;
        }
        else if(!_player.IsMove() && !_player.IsAttack())
        {
            Debug.Log("IsIdle sas");
             _typeOfCharacterState = TypeOfCharacterState.Idle;
        }
        else if (_player.IsMove() && !_player.IsAttack())
        {
            Debug.Log("IsMove sas");
         _typeOfCharacterState = TypeOfCharacterState.Move;   
        }
    
      
        
      switch (_typeOfCharacterState)
      {
          case TypeOfCharacterState.Idle:
           _player.IPlayerAnimator.PlayStay();
       //   _player.IEnemyAnimator.PlayStay();
          break;   
           case TypeOfCharacterState.Move:
      //     Debug.LogError("PLayer move");
        //  _player.IPlayerMovement.Move(_player);
         _player.IPlayerAnimator.PlayMovement();
          break; 
           case TypeOfCharacterState.Attack:
           Debug.Log("Attack");
          // _player.IPlayerAttackable.Attack();
          _player.IPlayerAnimator.PlayAttack();
          break;  
      }  
    }
    }
}
