using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPosition : MonoBehaviour
{
    [SerializeField] private BackgroundPartOfForest _partOfForest;
    [SerializeField] private Enemy _enemy;
    public void Spawn(TakerDamageVisitor visitor, GetterPlayer getterPlayer, EnemyFire enemyFire,CounterOfCharacterKills counterOfCharacterKills)
    {
       Enemy enemy =   Instantiate(_enemy,transform.position, Quaternion.identity);
       enemy.Visitor = visitor;
       enemy.GetterPlayer = getterPlayer;
       EnemyFire currentEnemyFire = Instantiate(enemyFire,transform.position,Quaternion.identity);
        currentEnemyFire.IsAppear = false;
        _partOfForest.OnTurnOn += enemy.TurnOn;
         _partOfForest.OnTurnOff += enemy.TurnOff;
        Debug.Log(counterOfCharacterKills);
    //  enemy.IEnemyHealth.CounterOfCharacterKills = counterOfCharacterKills;
      //enemy.IEnemyHealth.CounterOfCharacterKills.AddEnemy(enemy);
     //  Debug.Log(enemy.IEnemyHealth.CounterOfCharacterKills + " " + counterOfCharacterKills);
        
    }
}
