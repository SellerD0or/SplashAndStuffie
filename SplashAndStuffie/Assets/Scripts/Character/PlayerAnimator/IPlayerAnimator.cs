using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public interface IPlayerAnimator 
{
    float TimeForShoot {get;set;}
    bool IsAnimationEnded{get;set;}
   UnityArmatureComponent EnemyAnimator {get;set;}
   void PlayAttack();
   void PlayMovement();
   void PlayStay();
   TypeOfAnimation TypeOfAnimation{get;set;}
   IEnumerator CoolDown(float waitTime);
   void SwitchStates();
   List< AudioClip> AudioClips {get;set;}
    PlayerAudioSourse PlayerAudioSourse {get;set;}

}
