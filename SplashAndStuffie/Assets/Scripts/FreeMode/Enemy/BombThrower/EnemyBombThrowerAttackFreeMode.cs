using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombThrowerAttackFreeMode : EnemyAttackFreeMode
{
     [SerializeField] private float _attackSpeed = 2; 
     [SerializeField] private EnemyBombThrowerBulletFreeMode _bullet;    
     [SerializeField] private Transform _shotPosition;
     private bool _isBulletForGenerator;
     private bool _generatorCoolDown = false;
     private GeneratorFreeMode _generator;
     private void Update() {
        if (EnemyInformationFreeMode.CanAttack() && !IsEndedCoolDown)
        {
            //EnemyInformationFreeMode.ClosestPlayer.PlayerMovementFreeMode.PlayerHealth.TakeDamage(EnemyInformationFreeMode.Damage);
            StartCoroutine(CoolDown());
           _isBulletForGenerator = true;
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
        EnemyInformationFreeMode.EnemyAnimator.Attack();
         StartCoroutine(Create());
        IsEndedCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        IsEndedCoolDown = false;
    }
    public IEnumerator Create()
    {
      yield return new WaitForSeconds(2);
         EnemyBombThrowerBulletFreeMode butllet = Instantiate(_bullet,_shotPosition.position,Quaternion.identity );
        butllet.SetEnemy(EnemyInformationFreeMode);
        butllet.IsEnemyBullet = _isBulletForGenerator;
        Debug.Log(_isBulletForGenerator + " ATTACK !");
        if (_isBulletForGenerator == false)
        {
               butllet.Generator = _generator;
        }
    }
    public override void ContinieToMove()
    {
         Debug.Log("Continie TO MOVE");
         EnemyInformationFreeMode.Speed = EnemyInformationFreeMode.StartSpeed;
      //  EnemyInformationFreeMode.CanMove = true;  
    }
      public override void AttackGenerator(GeneratorFreeMode generator)
    {
      Debug.Log("ATTACK GENEERATOR");
    //  if (_isBulletForGenerator == true)
     // {
      if ( EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
      {
        _generator = generator;
        _isBulletForGenerator = false;
      //}
      if(IsEndedCoolDown == false)
      {
         EnemyInformationFreeMode.EnemyAnimator.ArmatureComponent.animation.FadeIn("shoot");  
      StartCoroutine(CoolDown());
      }  
      }
    }
}
