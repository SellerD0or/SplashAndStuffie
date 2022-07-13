using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeAttackFreeMode : EnemyAttackFreeMode
{
 [SerializeField] private float _attackSpeed = 2; 
     private void Update() {
        if (EnemyInformationFreeMode.CanAttack() && !IsEndedCoolDown)
        {
            if(EnemyInformationFreeMode.IsBewitched || EnemyInformationFreeMode.IsByPlayerControl)
            {
                EnemyInformationFreeMode.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(EnemyInformationFreeMode.Damage);
            }
            else  if(EnemyInformationFreeMode.IsBewitched && EnemyInformationFreeMode.IsByPlayerControl)
            {
            EnemyInformationFreeMode.ClosestPlayer.PlayerMovementFreeMode.PlayerHealth.TakeDamage(EnemyInformationFreeMode.Damage);
            }
            StartCoroutine(CoolDown());
            EnemyInformationFreeMode.EnemyAnimator.Attack();
           // EnemyInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            //Debug.Log("COOL you can move" );
            //if(!CanAttack)
           // {
           // EnemyInformationFreeMode.CanMove = false;
        //   transform.position = Vector3.MoveTowards(transform.position, new Vector3(EnemyInformationFreeMode.ClosestPlayer.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
         // if (Vector3.Distance(transform.position,EnemyInformationFreeMode.ClosestPlayer.transform.position) <= 2)
        //  {
           //   CanAttack = true;
            //EnemyInformationFreeMode.CanMove = true;
        //  }
         //   }
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
        if(EnemyInformationFreeMode.CanAttack()  == false && EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
          generator.TakeDamage(EnemyInformationFreeMode.Damage,EnemyInformationFreeMode);
    }
}
