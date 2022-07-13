using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd1AnimatorFreeMode : PlayerAnimatorFreeMode
{
     private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private void Start() {
     Player = GetComponent<PlayerInformationFreeMode>(); 
    }
    public override void Attack()
    {
        if( _canShoot)
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
        if(!_canShoot && !_canStay)
        {
                      Debug.Log("idle");

       ArmatureComponent.animation.Play("idle");
         _canStay = false;
           Invoke(nameof(Stay), IdleTime);
      //  StartCoroutine(CoolDown(IdleTime));
        }
    }

    public override void Run()
    {
        if( !_canShoot && !_canMove)
        {   
                      Debug.Log("run");

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
        Idle();
   }
    public override void PlayRunAnimation()
    {
         ArmatureComponent.animation.FadeIn("run");
    }
}
