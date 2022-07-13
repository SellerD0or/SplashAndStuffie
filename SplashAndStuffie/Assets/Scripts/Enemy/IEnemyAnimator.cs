using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public interface IEnemyAnimator 
{
   bool IsAnimationEnded{get;set;}
   UnityArmatureComponent EnemyAnimator {get;set;}
   void PlayAttack();
   void PlayMovement();
   void PlayStay();
   TypeOfAnimation TypeOfAnimation{get;set;}
   IEnumerator CoolDown(float waitTime);
   void SwitchStates();
}
