using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyState : MonoBehaviour
{
   protected readonly IEnemyStateSwitcher _stateSwitcher;
   protected readonly Enemy _enemy;
   public BaseEnemyState(IEnemyStateSwitcher stateSwitcher, Enemy enemy)
   {
       _stateSwitcher = stateSwitcher;
       _enemy = enemy;
   }
   public abstract void Attack();
   public abstract void Run();
   public abstract void Stay();
}
