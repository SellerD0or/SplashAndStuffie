using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public interface IPlayerAttackable 
{

   event UnityAction OnAttack;
   bool IsStopped{get;set;}
   PlayerInterface PlayerInterface {get;set;}
   bool IsReloading {get;set;}
    float CurrentTime{get;set;}
    float Timer{get;set;}
 float CoolDownTime{get;set;}
 float ResultTime {get;set;}
    float WaitTime{get;set;}
    bool IsCoolDown {get;set;}
    bool IsAttack{get;set;}
 void Attack();
 void SetPlayer(Player player);
 IEnumerator CoolDown();
void Reload();
void StartReload();
void UseAttack();
}
