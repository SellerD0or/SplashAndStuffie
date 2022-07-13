using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTattiAttackFreeMode : PlayerAttackFreeMode
{
    // [SerializeField] private float _attackSpeed = 2; 
     [SerializeField] private PlayerTattiRoarFreeMode _roar;
     private bool _isClose;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !AbleToAttck )
        {
             Stop();
             ShowAbiliy();
            Attack();
            PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            Debug.Log("COOL you can move" );
            //PlayerInformationFreeMode.CanMove = false;
           // if(!PlayerInformationFreeMode.PlaceRow.IsLowPlace)
         //  transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerInformationFreeMode.ClosestEnemy.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
           //else
          //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, PlayerInformationFreeMode.ClosestEnemy.transform.position.y), _attackSpeed * Time.deltaTime);
        //  if (Vector3.Distance(transform.position,PlayerInformationFreeMode.ClosestEnemy.transform.position) <= 1)
         // {
           
          //  PlayerInformationFreeMode.CanMove = true;
            AbleToAttck = true;
            _isClose = true;
          //}
        }
           if ( _isClose == false)
        {
          if(PlayerInformationFreeMode.PlaceRow.Enemies.Count <= 0)
          {
          _roar.Close();
          _isClose = true;
          }
        }
    }
    private void Attack()
    {
        _roar.Open();
    }
 
    //private void OnTriggerStay2D(Collider2D other) {
    //    if (!IsEndedCoolDown && other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
  //      {
    //        PlayerHealth.PlayerInformation.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerInformationFreeMode.Damage);
//            StartCoroutine(CoolDown());
 //       }
  //  }

    public override IEnumerator CoolDown()
    {
        IsEndedCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        IsEndedCoolDown = false;
    }

    public override void Stop()
    {
        PlayerHealth.PlayerInformation.Speed = 0;
    }

    public override void ContinieToMove()
    {
        PlayerHealth.PlayerInformation.Speed = PlayerHealth.PlayerInformation.StartSpeed;
    }
}
