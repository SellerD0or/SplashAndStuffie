using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public  interface IEnemyHealth 
{
   float TimeForExtraDamage {get;set;}
   EnemyFire EnemyFire {get;set;}
   CounterOfCharacterKills CounterOfCharacterKills{ get;set;}
   bool CanAttack{get;set;}
   void TakeDamage(int damage);
   int Health { get; set; }
   int MaxHealth {get;set;}
   event UnityAction OnDestroy;
   event UnityAction OnTakeDamage;
   void Destroy();
   void CreateParticlies();
   ParticleSystem ParticleSystem{get;set;}
   IEnumerator CoolDown();
   void StartApplyingExraDamage(int damage);
   IEnumerator ApplyExtraDamage(int damage);
}
