using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShamanAttackFreeMode : EnemyAttackFreeMode
{
      [SerializeField] private float _attackSpeed = 2; 
     [SerializeField] private EnemyShamanBulletFreeMode _bullet;
     [SerializeField] private EnemyShamanShadow _shadow;    
      private Vector2 _shotPosition;
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
      if( EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
      {
      if(_isBulletForGenerator == false)
      {
        _shotPosition = new Vector2(_generator.transform.position.x, _generator.transform.position.y);
      }
      else
      {
        _shotPosition = new Vector2(EnemyInformationFreeMode.ClosestPlayer.transform.position.x, EnemyInformationFreeMode.ClosestPlayer.transform.position.y);
      }
      }
      else if(EnemyInformationFreeMode.IsBewitched || EnemyInformationFreeMode.IsByPlayerControl)
      {
             _shotPosition = new Vector2(EnemyInformationFreeMode.ClosestEnemy.transform.position.x, EnemyInformationFreeMode.ClosestEnemy.transform.position.y);
      }
      Instantiate(_shadow,_shotPosition,Quaternion.identity);
         EnemyShamanBulletFreeMode butllet = Instantiate(_bullet,_shotPosition,Quaternion.identity );
       if (_isBulletForGenerator == false)
        {
               butllet.Generator = _generator;
        }
        butllet.SetEnemy(EnemyInformationFreeMode);
        butllet.PositionYForStop = _shadow.transform.position.y;
        butllet.transform.position = new Vector3(butllet.transform.position.x, butllet.transform.position.y + 7, butllet.transform.position.z);
        butllet.IsEnemyBullet = _isBulletForGenerator;
        Debug.Log(_isBulletForGenerator + " ATTACK !");
       
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
       if(EnemyInformationFreeMode.IsBewitched ==false && EnemyInformationFreeMode.IsByPlayerControl== false)
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
