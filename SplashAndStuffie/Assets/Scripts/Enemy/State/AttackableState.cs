using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableState : BaseEnemyState
{
    public AttackableState(IEnemyStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
    {
    }

    public override void Attack()
    {
    //    Debug.Log("Attackable. Attack");
        if(_enemy.CanAttack() && _enemy.CanStop() == false)
        {
         //  _enemy.IEnemyAttackable.Attack(_enemy.Player, _enemy);
        //   _enemy.IEnemyAnimator.PlayAttack();
           //_enemy.IEnemyAnimator.TypeOfAnimation = TypeOfAnimation.Shoot;
               return;
        }
        
        _stateSwitcher.SwitchState<RunnableState>();

    }

    public override void Run()
    {
//        Debug.Log("Attackable. Run");
      // _stateSwitcher.SwitchState<RunnableState>();
    }

    public override void Stay()
    {
     
    }
}
