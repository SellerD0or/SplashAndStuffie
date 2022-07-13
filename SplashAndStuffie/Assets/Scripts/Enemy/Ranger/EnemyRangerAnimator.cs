using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
[RequireComponent(typeof(UnityArmatureComponent))]

public class EnemyRangerAnimator : MonoBehaviour, IEnemyAnimator
{
 
  public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;

    private void Start() {
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
    }
    private void Update() {
        SwitchStates();
    }
    public void SwitchStates()
    {
        if(!IsAnimationEnded)
        {
        switch (TypeOfAnimation)
        {
            case TypeOfAnimation.Idle:
            
            EnemyAnimator.animation.Play("idle");
            StartCoroutine(CoolDown(2));
            break;
            case TypeOfAnimation.Shoot:
            EnemyAnimator.animation.Play("shoot");
            StartCoroutine(CoolDown(4));
            break;
            case TypeOfAnimation.Run:
            EnemyAnimator.animation.Play("run");
            StartCoroutine(CoolDown(2));
            break;
            default:
            EnemyAnimator.animation.Play("idle");
            StartCoroutine(CoolDown(2));
            break;
        }
        }
    }
    public void PlayAttack()
    {
        TypeOfAnimation = TypeOfAnimation.Shoot;
    }

    public void PlayMovement()
    {
        TypeOfAnimation = TypeOfAnimation.Run;
    }

    public void PlayStay()
    {
       TypeOfAnimation = TypeOfAnimation.Idle;
    }

    public IEnumerator CoolDown(float waitTime)
    {
        IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
       IsAnimationEnded = false;
    }
}
