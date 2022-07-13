using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovement
{
    float MinXForMovement {get;set;}
    bool CanNormalMove{get;set;}
    void Move(Enemy _enemy);
}
