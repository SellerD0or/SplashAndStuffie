using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRongAnimatorFreeMode : PlayerAnimatorFreeMode
{
    private bool _isEating = false;
    private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;

    public bool IsEating { get => _isEating; set => _isEating = value; }

    public override void Attack()
    {
        if( _canShoot && !IsEating)
        {
            Debug.Log("attack");
        ArmatureComponent.animation.FadeIn("shoot");
         _canShoot = false;
           Invoke(nameof(Shoot),AttackTime);
      //   StartCoroutine(CoolDown(AttackTime));
        }
    }

    public override IEnumerator CoolDown(float time)
    {
        CanStart = true;
      yield return new WaitForSeconds(time);   
      CanStart = false;
    }

    public override void Idle()
    {
        if(IsEating)
        {
       ArmatureComponent.animation.Play("idle");
         IsEating = false;
           Invoke(nameof(Stay), IdleTime);
        }
    }

    public override void Run()
    {
        if( !_canShoot && !_canMove && !IsEating)
        {
          PlayRunAnimation();            
        _canMove = false;
           Invoke(nameof(Move), RunTime);
      //   StartCoroutine(CoolDown(RunTime));
        }
    }
     private void Stay()
   {
       _canStay = true;
   }
      private void Move()
   {
       _canMove = true;
   }
   private void Shoot()
   {
       _canShoot = true;
       ArmatureComponent.animation.FadeIn("alt_run");
   }
    public override void PlayRunAnimation()
    {
         ArmatureComponent.animation.FadeIn("run");
    }
}
