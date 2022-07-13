using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMummyHatAttackFreeMode : PlayerAttackFreeMode
{
       private bool _isCoolDown;
       [SerializeField] private PlayerMummyHatPointFreeMode _playerMummyHatPoint;
       private PlayerInformationFreeMode _player;
       [SerializeField]private float _timeForRemoving;
       private PlayerMummyHatAbilityFreeMode _ability;
   private void Start() {
     _ability = GetComponent<PlayerMummyHatAbilityFreeMode>();
       _player = GetComponent<PlayerInformationFreeMode>();
       _playerMummyHatPoint.PlayerInformation = _player;
   }

     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !AbleToAttck )
        {
            ShowAbiliy();
             Stop();
            // if(!_isCoolDown)
           //  {
           // StartCoroutine(Create());
          //   }
           // Debug.Log("COOL you can move" );
            //PlayerInformationFreeMode.CanMove = false;
          // transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerInformationFreeMode.ClosestEnemy.transform.position.x, transform.position.y), _attackSpeed * Time.deltaTime);
           if(!_isCoolDown && _ability.IsAbilityUsed == false)
             {
            StartCoroutine(Create());
             }
        }
    }
       private IEnumerator Create()
    {
             _player.PlayerAnimatorFreeMode.Run();
       _playerMummyHatPoint.Collider.enabled = true;
       _player.PlayerAnimatorFreeMode.Attack();
        _isCoolDown = true;
        Invoke(nameof(Remove),_timeForRemoving);
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;

    }
    private void Remove()
    {
          _playerMummyHatPoint.Collider.enabled = false;
    }

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
