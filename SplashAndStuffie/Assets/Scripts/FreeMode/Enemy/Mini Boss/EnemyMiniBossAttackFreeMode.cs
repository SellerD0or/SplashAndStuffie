using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMiniBossAttackFreeMode : EnemyAttackFreeMode
{
    private bool _isGeneratorAttack = false;
    private void Start() {
          if(EnemyInformationFreeMode.PlaceRow.IsRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        if(EnemyInformationFreeMode.PlaceRow.IsLowPlace == false)
        transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    } 
      private void Update() 
     {
        if (EnemyInformationFreeMode.CanAttack() && !IsEndedCoolDown)
        {
            _isGeneratorAttack = true;
            if (EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
            {
            EnemyInformationFreeMode.ClosestPlayer.PlayerMovementFreeMode.PlayerHealth.TakeDamage(EnemyInformationFreeMode.Damage);
            } 
            else if(EnemyInformationFreeMode.IsBewitched  || EnemyInformationFreeMode.IsByPlayerControl)
            {
                EnemyInformationFreeMode.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(EnemyInformationFreeMode.Damage);
            }
            StartCoroutine(CoolDown());
        }
    }

    public override void Stop()
    {
        Debug.Log("Stoop TO MOVE");
        EnemyInformationFreeMode.Speed = 0;
      //  EnemyInformationFreeMode.CanMove = false;        
    }

    public override IEnumerator CoolDown()
    {
        if (_isGeneratorAttack)
        {
             EnemyInformationFreeMode.EnemyAnimator.Attack();
        }
        else
        {
            EnemyInformationFreeMode.EnemyAnimator.ArmatureComponent.animation.FadeIn("jump");
        }
        IsEndedCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        IsEndedCoolDown = false;
    }

    public override void ContinieToMove()
    {
         Debug.Log("Continie TO MOVE");
         EnemyInformationFreeMode.Speed = EnemyInformationFreeMode.StartSpeed;
      //  EnemyInformationFreeMode.CanMove = true;  
    }

    public override void AttackGenerator(GeneratorFreeMode generator)
    {
        if(EnemyInformationFreeMode.CanAttack()  == false && IsEndedCoolDown == false && EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
        {
            _isGeneratorAttack = false;
          generator.TakeDamage(EnemyInformationFreeMode.Damage,EnemyInformationFreeMode);
          StartCoroutine(CoolDown());
        }
    }
}
