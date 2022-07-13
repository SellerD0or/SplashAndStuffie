using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd2AttackFreeMode : PlayerAttackFreeMode
{
    private bool _isJumoing = false;
    [SerializeField] private float _attackSpeed = 2; 
    private bool _isCoolDown;
    [SerializeField] private float _range = 2;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !AbleToAttck )
        {
             Stop();
             ShowAbiliy();
            PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            Debug.Log("COOL you can move" );
            Invoke(nameof( Jump),2);
            if (_isCoolDown == false && _isJumoing== false)
            {
                 StartCoroutine(CoolDown());
            }
            //PlayerInformationFreeMode.CanMove = false;
            if(_isJumoing)
            {
            if(!PlayerInformationFreeMode.PlaceRow.IsLowPlace)
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerInformationFreeMode.ClosestEnemy.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
           else
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, PlayerInformationFreeMode.ClosestEnemy.transform.position.y), _attackSpeed * Time.deltaTime);
           if (Vector3.Distance(transform.position,PlayerInformationFreeMode.ClosestEnemy.transform.position) <= 1)
           {
               Stop();
          //  PlayerInformationFreeMode.CanMove = true;
            // AbleToAttck = true;
             _isJumoing = false;
            }
            }
        }
    }
    private void Jump()
    {
        _isJumoing =  true;
    }

  /*  private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
        {
            Debug.LogError("YOU TRIGGER " + enemy  +" if false you can attak!" + _isCoolDown);
            if(PlayerHealth.PlaceRow.Enemies.Contains(enemy) && _isCoolDown == false)
            {
             //   enemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerHealth.PlayerInformation.Damage);
            //    Stop();
           // PlayerHealth.PlayerInformation.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerInformationFreeMode.Damage);
            }
        }
    }*/

    public override IEnumerator CoolDown()
    {
        _isCoolDown = true;
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
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;
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
