using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAkiAttackFreeMode : PlayerAttackFreeMode
{
    [SerializeField] private float _range = 5;
      [SerializeField] private int _maxHealthForHealing = 75;
    [SerializeField] private int _percentOfAdditionHealth = 3;
    private bool _isCoolDown;
        [SerializeField] private Transform _shotPosition;

    [SerializeField] private PlayerAkiBulletFreeMode _playerAkiBullet;
    private void Start() {
            Ability.CanUseAbility = true;
    }
     private void Update() {
        if (PlayerInformationFreeMode.CanAttack() && !IsEndedCoolDown)
        {
            Debug.Log("AKI USE ABLITY");
            ShowAbiliy();
             Stop();
             if(!_isCoolDown)
             {
            StartCoroutine(Create());
            Invoke(nameof(CreateBullet),2);
             }
        }
    }
     private IEnumerator Create()
    {
       /* PlayerInformationFreeMode[] players = FindObjectsOfType<PlayerInformationFreeMode>();
        List<PlayerInformationFreeMode> selectedPlayers = new List<PlayerInformationFreeMode>();
       foreach (var player in players)
       {
            if (Vector2.Distance(player.transform.position, transform.position) < _range)
            {
                if (player.Health <= player.MaxHealth * _maxHealthForHealing / 100)
               {
                   player.Health = player.MaxHealth * _percentOfAdditionHealth /100;
               }
            }
       }
       
              
         PlayerHealth.PlayerInformation.PlayerAnimatorFreeMode.Attack();*/
        _isCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;

    }
    private void CreateBullet()
    {
          PlayerInformationFreeMode.PlayerAnimatorFreeMode.Attack();
            PlayerAkiBulletFreeMode butllet = Instantiate(_playerAkiBullet,_shotPosition.position,Quaternion.identity );
            Debug.Log("Shoot");
            butllet.SetPlayer(GetComponent<PlayerInformationFreeMode>());
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
