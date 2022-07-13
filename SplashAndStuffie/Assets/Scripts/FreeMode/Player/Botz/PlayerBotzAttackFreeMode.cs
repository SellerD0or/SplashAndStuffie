using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBotzAttackFreeMode : PlayerAttackFreeMode
{
    [SerializeField] private float _range = 3f;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !AbleToAttck )
        {
             Stop();
             ShowAbiliy();
           // PlayerInformationFreeMode.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerInformationFreeMode.Damage);
           if(IsEndedCoolDown== false && PlayerInformationFreeMode.PlaceRow.Enemies.Count > 0)
           {
           StartCoroutine(CoolDown());
           }
           // Debug.Log("COOL you can move" );
            //PlayerInformationFreeMode.CanMove = false;
           // if(!PlayerInformationFreeMode.PlaceRow.IsLowPlace)
          // transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerInformationFreeMode.ClosestEnemy.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
         //  else
         //  transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, PlayerInformationFreeMode.ClosestEnemy.transform.position.y), _attackSpeed * Time.deltaTime);
         // if (Vector3.Distance(transform.position,PlayerInformationFreeMode.ClosestEnemy.transform.position) <= 1)
         // {

         // }
          //  PlayerInformationFreeMode.CanMove = true;
           // AbleToAttck = true;
        }
    }

    /*private void OnTriggerStay2D(Collider2D other) {
           if (!IsEndedCoolDown && other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
        {
            
            StartCoroutine(CoolDown());
        }
    }*/
  

    public override IEnumerator CoolDown()
    {
        Debug.LogError("Attack");
          Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position,_range);
        foreach (var collider in collider2Ds)
        {
            if (collider.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemyInformation))
            {
                if (PlayerHealth.PlaceRow.Enemies.Contains(enemyInformation) || (PlayerHealth.PlaceRow.HigherPlaceRow.Enemies.Contains(enemyInformation) && PlayerHealth.PlaceRow.IsTheHighestPlaceRow == false))
                {
                    Debug.LogError("take damage to: " + enemyInformation);
                    enemyInformation.EnemyAttack.EnemyHealth.TakeDamage(PlayerHealth.PlayerInformation.Damage);
                }
            }
        }
        PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
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
