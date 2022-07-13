using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelAnimatorFreeMode : PlayerAnimatorFreeMode
{
     private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private bool _canUse = true;
    [SerializeField] private float _abilityTime = 2f;

    public bool CanUse { get => _canUse; set => _canUse = value; }

    public override void Attack()
    {
        if( _canShoot && !CanUse)
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
        if(! !_canShoot && !_canStay && !CanUse)
        {
       ArmatureComponent.animation.Play("idle");
         _canStay = false;
           Invoke(nameof(Stay), IdleTime);
      //  StartCoroutine(CoolDown(IdleTime));
        }
    }

    public override void Run()
    {
        if( !_canShoot && !_canMove && !CanUse)
        {
          PlayRunAnimation();            
        _canMove = false;
           Invoke(nameof(Move), RunTime);
      //   StartCoroutine(CoolDown(RunTime));
        }
    }
    public override void UseAbility()
    {
        if(CanUse)
        {
        ArmatureComponent.animation.FadeIn("ult");
        CanUse = false;
        Invoke(nameof(Use),_abilityTime);
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
     private void Use()
   {
       CanUse = true;
   }
    public override void PlayRunAnimation()
    {
         ArmatureComponent.animation.FadeIn("run_fast");
    }
}
