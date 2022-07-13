using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseEnemyState
{
    public IdleState(IEnemyStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
    {
    }

    public override void Attack()
    {
        Debug.Log("IdleState. Attack");
      

    }

    public override void Run()
    {
        Debug.Log("IdleState. Run");
      // _stateSwitcher.SwitchState<RunnableState>();
    }

    public override void Stay()
    {
       Debug.Log("IdleState. Stay");
        if(_enemy.CanStop())
        {
         //  _enemy.IEnemyAnimator.PlayStay();
         //  _enemy.IEnemyAnimator.TypeOfAnimation = TypeOfAnimation.Idle;
               return;
        }
        _stateSwitcher.SwitchState<RunnableState>();
    }
}
