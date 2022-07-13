
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnableState : BaseEnemyState
{
    public RunnableState(IEnemyStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
    {
    }

    public override void Attack()
    {
//      Debug.Log("Runnable. Attack");
      
      //_stateSwitcher.SwitchState<AttackableState>();
    }

    public override void Run()
    {
    //  Debug.Log("Runnable. Run");
          if (_enemy.CanAttack() == false)
       {
         if(_enemy.CanStop() == false)
         {
//           _enemy.IEnemyMovement.Move(_enemy);
  //         _enemy.IEnemyAnimator.PlayMovement();
    //       _enemy.IEnemyAnimator.TypeOfAnimation = TypeOfAnimation.Run;
           return;
         }
        // else
        // {
          // _enemy.IEnemyAnimator.PlayStay();
          // _enemy.IEnemyAnimator.TypeOfAnimation = TypeOfAnimation.Idle;
          // _stateSwitcher.SwitchState<IdleState>();
           //return;
        // }
           
          
       }
       _stateSwitcher.SwitchState<AttackableState>();
       
       
    }

    public override void Stay()
    {
        
    }
}
