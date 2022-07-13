using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelAttackFreeMode : PlayerAttackFreeMode
{
  [SerializeField] private float _attackSpeed = 2; 
    [SerializeField] private float _range = 5;
    [SerializeField] private PlayerAxelSphereFreeMode _bullet;
    //[SerializeField] private float _waitTimeForCreating = 1;
    [SerializeField] private Transform _shotPosition;
    private bool _isCoolDown;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !IsEndedCoolDown )
        {
            ShowAbiliy();
             Stop();
             if(!_isCoolDown)
             {
            StartCoroutine(Create());
             }
           // Debug.Log("COOL you can move" );
            //PlayerInformationFreeMode.CanMove = false;
          // transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerInformationFreeMode.ClosestEnemy.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
         // if (Vector3.Distance(transform.position,PlayerInformationFreeMode.ClosestEnemy.transform.position) <= _range)
        //  {
           
          //  PlayerInformationFreeMode.CanMove = true;
            //AbleToAttck = true;
         // }
        }
    }
    private IEnumerator Create()
    {
                PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            PlayerAxelSphereFreeMode butllet = Instantiate(_bullet,_shotPosition.position,Quaternion.identity );
            Debug.Log("Shoot");
            butllet.SetPlayer(GetComponent<PlayerInformationFreeMode>());
        _isCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;

    }
   /* private void OnTriggerStay2D(Collider2D other) {
        if (!IsEndedCoolDown && other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
        {
            PlayerHealth.PlayerInformation.ClosestEnemy.EnemyAttack.EnemyHealth.TakeDamage(PlayerInformationFreeMode.Damage);
            StartCoroutine(CoolDown());
        }
    }*/

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
