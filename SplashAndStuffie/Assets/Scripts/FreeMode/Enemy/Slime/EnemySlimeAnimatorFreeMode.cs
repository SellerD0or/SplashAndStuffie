using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeAnimatorFreeMode : EnemyAnimtatorFreeMode
{
       private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private EnemyInformationFreeMode _enemy;
    private void Start() {
        _enemy = GetComponent<EnemyInformationFreeMode>();
         PlayRunAnimation();
    }
    public override void Attack()
    {
        if( _canShoot && _enemy.PlaceRow.Players.Count > 0)
        {
            if(_enemy.PlaceRow.IsLowPlace == false )
       ArmatureComponent.animation.FadeIn("shoot");
       else
       {
           Debug.LogError("shoot_alt");
                  ArmatureComponent.animation.FadeIn("shoot_alt");
       }
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
            if(_enemy.PlaceRow.IsLowPlace == false)
       ArmatureComponent.animation.Play("idle");
       else
       {
        ArmatureComponent.animation.Play("idle_alt");
       }
         _canStay = false;
           Invoke(nameof(Stay), IdleTime);
      //  StartCoroutine(CoolDown(IdleTime));
        }
    }

    public override void Run()
    {
        if( !_canShoot && !_canMove)
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
   }
    public override void PlayRunAnimation()
    {
        if(_enemy.PlaceRow.IsLowPlace == false)
         ArmatureComponent.animation.FadeIn("jump");
         else
         {
         
                      ArmatureComponent.animation.FadeIn("jump_alt");
         }
    }
}
