using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRongAttack : MonoBehaviour, IPlayerAttackable
{
    public bool IsStopped { get ; set; }
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private PlayerRongAnimator _playerRongAnimator;
    private Player _player;

    public bool IsAttack { get ; set ; }
    public bool IsCoolDown {get;set;}
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public float CoolDownTime { get => _coolDown; set => _coolDown = value; }
    public float Timer { get ; set; }
    public float CurrentTime { get ; set ; }
    [SerializeField] private float _resultTime;
    public float ResultTime { get => _resultTime ; set => _resultTime = value; }
    public bool IsReloading { get ; set ; } = true;
    public PlayerInterface PlayerInterface { get ; set; }

    [SerializeField] private float _coolDown = 1.5f;
       private bool _isAttacking;
     private float _timerAttack =0;
     private float _timeForMiddleAttack =0;
       private GetterPlayer _getterPlayer;
       private bool _isMiddleAttack = false;
       [SerializeField] private float _coolDownForMiddleAttack = 2;

    public event UnityAction OnAttack;

    private void OnEnable() {
           _playerRongAnimator.IsAlternativeMovevent = false;
        IsCoolDown = false;
        _playerRongAnimator.PlayStay();
       }
    private void Start() {
                 _getterPlayer =FindObjectOfType<GetterPlayer>();

        PlayerInterface = FindObjectOfType<PlayerInterface>();
        //StartCoroutine(Reload());
    }
      public void UseAttack()
    {
        OnAttack?.Invoke();
    }
    private void Update()
     {
          if(IsStopped == false)
      {
        Attack();
      }
           if(!IsReloading)
        {
       // Reload();
        }
         Heal();
         if (_isMiddleAttack)
         {
             _timeForMiddleAttack+= Time.deltaTime;
             if (_timeForMiddleAttack > _coolDownForMiddleAttack)
             {
                 _isMiddleAttack = false;
                 _timeForMiddleAttack = 0;
             }
         }
    }
       public void Reload()
    {
          //   Timer = Timer + Time.deltaTime;
         // if (Timer > 1)
         // {
CurrentTime ++;
              if (CoolDownTime >= CurrentTime)
              {
                  ResultTime = CoolDownTime - CurrentTime;
              }
            if(CurrentTime >= CoolDownTime)
            {
                IsCoolDown = false;
                _isAttacking =false;
                IsReloading = true;
                 PlayerInterface.DisactiveSkill();
                CurrentTime = 0;
            }
               else
        {
            PlayerInterface.ActiveSkill();
              _isAttacking = true;
        }
               
     //      Timer = 0;
     
        //}
    }
    private void Heal()
    {
        Debug.Log("Try rong! " + _isAttacking);
        if(_isAttacking)
        {
          _timerAttack = _timerAttack + Time.deltaTime;
          if (_timerAttack > 1)
          {
         //if (IsCoolDown)
              //  {
                    Debug.LogError("TRY HEALTH BY RONG!!!");
                    foreach (var player in PlayerInterface.GetterPlayer.Players)
                    {
                        if (player.PlayerHealth.MaxHealth * 100 / 103 >= player.PlayerHealth.Health)
                        {
                            Debug.LogError("COOOL HEALTH BY RONG");
                            player.PlayerHealth.Health = player.PlayerHealth.Health * 103 / 100;
                                   HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == player.Name);
        healthOutput?.TakeDamage();         

                        }
                    }
               // }
                _timerAttack = 0;
          }
        }
    }
    public void Attack()
    {
        if(!IsCoolDown)
        {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsReloading = false;
            IsAttack = true;
            _isAttacking = true;
            StartCoroutine(CoolDown());
            StartCoroutine(Rechange());
        }
        }
                else if(!Input.GetKeyDown(KeyCode.E))
        {
            IsAttack =false;
        }
       
    }
    private IEnumerator Rechange()
    {
        _player.IPlayerMovement.AbleToMove = true;
        yield return new WaitForSeconds(1.5f);
        _player.IPlayerMovement.AbleToMove = false;
       //  _playerRongAnimator.IsAlternativeMovevent = true;

    }
    public IEnumerator CoolDown()
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _playerRongAnimator.IsAlternativeMovevent = false;
        IsCoolDown = false;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent(out Enemy enemy) && _isMiddleAttack == false)
        {
            _player.Ability.ReloadAmount(0.5f);
             UseAttack();
            enemy.IEnemyHealth.TakeDamage(_player.Damage);
            _isMiddleAttack = true;
        }
    }
    public void SetPlayer(Player player)
    {
        _player = player;
    }
      public void StartReload()
    {
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
    }
}
