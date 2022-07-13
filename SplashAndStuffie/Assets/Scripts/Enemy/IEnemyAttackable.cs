using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttackable 
{
    float CoolDown{get;set;}
    bool IsStayed{get;set;}
    IEnumerator Reload();
    void Attack(Player _player, Enemy _enemy);
}
