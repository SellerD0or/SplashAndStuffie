using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomberAttackFreeMode : PlayerAttackFreeMode
{
     [SerializeField] private float _attackSpeed = 2; 
    [SerializeField] private float _range = 5;
    [SerializeField] private PlayerDd1BulletFreeMode _bullet;
    //[SerializeField] private float _waitTimeForCreating = 1;
    [SerializeField] private Transform[] _shotPositions;
    private bool _isCoolDown;
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !IsEndedCoolDown)
        {
            ShowAbiliy();
             Stop();
             if(!_isCoolDown)
             {
            StartCoroutine(CoolDown());
             }
        }
    }
  
 

    public override IEnumerator CoolDown()
    {
           PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
           foreach (var position in _shotPositions)
           {
               PlayerDd1BulletFreeMode butllet = Instantiate(_bullet,position.position,Quaternion.identity );
            Debug.Log("Shoot");
            butllet.SetPlayer(GetComponent<PlayerInformationFreeMode>());
           }
            
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
