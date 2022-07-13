using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateSwitcher 
{
   void SwitchState<T>() where T: BaseEnemyState;
}
