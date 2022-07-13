using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRongAttackFreeMode : PlayerAttackFreeMode
{
   // [SerializeField] private float _attackSpeed = 2; 
     [SerializeField] private PlayerRongFinderFreeMode _finder;
     private bool _isReloaded;
     [SerializeField] private float _range;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !AbleToAttck )
        {
             Stop();
             ShowAbiliy();
            Attack();
            PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            if (_isReloaded == false && PlayerInformationFreeMode.PlaceRow.Enemies.Count > 0)
            {
              StartCoroutine(Reload());
            }
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
          //}
        }
     
    }
    private void Attack()
    {
         foreach (var player in _finder.Players)
                    {
                        if (player.MaxHealth * 0.97f >= player.Health)
                        {
                            Debug.Log(player.Health + " top " + player.Name);
                            player.Health = player.Health * 103 / 100;
                        }
                    }
    }
    /*private void OnTriggerStay2D(Collider2D other) {
      if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy) && _isReloaded == false)
      {
        if (PlayerInformationFreeMode.PlaceRow.Enemies.Contains(enemy))
        {
          enemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerInformationFreeMode.Damage);
           StartCoroutine(Reload());
        }
      }
    }*/
    private IEnumerator Reload()
    {
      _isReloaded = true;
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position,_range);
        foreach (var collider in collider2Ds)
        {
            if (collider.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemyInformation))
            {
                if (PlayerHealth.PlaceRow.Enemies.Contains(enemyInformation) || (PlayerHealth.PlaceRow.HigherPlaceRow.Enemies.Contains(enemyInformation) && PlayerHealth.PlaceRow.IsTheHighestPlaceRow == false))
                {
                    enemyInformation.EnemyAttack.EnemyHealth.TakeDamage(PlayerHealth.PlayerInformation.Damage);
                }
            }
        }
      yield return new WaitForSeconds(1);
      _isReloaded = false;
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
