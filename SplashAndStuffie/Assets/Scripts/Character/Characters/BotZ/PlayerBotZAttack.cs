using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBotZAttack : MonoBehaviour, IPlayerAttackable
{
  public bool IsStopped { get ; set; }
     private Player _player;
     [SerializeField] private float _waitTime = 4f;
     private Enemy[] _enemies;
     private Enemy _closestEnemy;
    public bool IsAttack { get ; set ; }
    public bool IsCoolDown {get;set;}
      public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public Player Player { get => _player; set => _player = value; }
    public float Angle { get => _angle; set => _angle = value; }
    public Enemy ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }

    private float _angle;
      private bool _isJumping;
  public float CoolDownTime { get => _coolDown; set => _coolDown = value; }
    public float Timer { get ; set; }
    public float CurrentTime { get ; set ; }
    public float ResultTime { get ; set ; }
    public bool IsReloading { get; set ; } = true;
    public PlayerInterface PlayerInterface { get ; set; }
    [SerializeField] private float _coolDown = 1.5f;         
     private bool _ableAttack =false;
     private bool _isTouchingEnemy;
     private bool _ableToFight = true;
     [SerializeField] private int _superDamage = 3200;

    public event UnityAction OnAttack;

    private void Start() {
         PlayerInterface = FindObjectOfType<PlayerInterface>();
     }
    private void Update() {
       if(IsStopped == false)
      {
        Attack();
      }
        if(!IsReloading)
        {
      //  Reload();
        }
    }
    public void Attack()
    {
       // if (Input.GetKeyDown(KeyCode.E) && Player.Ability.AmountOfReloadig == Player.Ability.MaxAmountOfReloading)
       // {
       //   ClosestEnemy.IEnemyHealth.TakeDamage(_superDamage);
       //       Player.Ability.DestroyAbility();
        //}
       if(!IsCoolDown)
       { 
       if (Input.GetKeyDown(KeyCode.E) && !_ableAttack)
       {
           if(_ableToFight)
           {
             IsCoolDown = true;
               IsReloading = false;
               _player.IPlayerMovement.IsAttacking = true;
               _player.IPlayerMovement.AbleToMove = true;
               _ableAttack = true;
               _player.Rigidbody2D.velocity = Vector2.zero;
                   IsAttack = true;
                   Invoke(nameof(StopAttacking),0.6f);
                   if(_isTouchingEnemy  == true)
                   {
                    Player.Ability.ReloadAmount(1);
                  Invoke(nameof(StartToAttack),1f);
                   }
            StartCoroutine(CoolDownAttack());
            //StartCoroutine(CoolDownAttack());
          // StartCoroutine(Jump());
           StartCoroutine(CoolDown());
           }
         //  _enemies = FindObjectsOfType<Enemy>();
       // FindClosestEnemy();
     //   if (Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 1)
        //{
         //   
            
         // StartCoroutine(Reload());
       // }
           
       }
       else if(!Input.GetKeyDown(KeyCode.E) )
       {
           
           //IsAttack = false;
            _player.IPlayerMovement.IsAttacking = false;
              _player.IPlayerMovement.AbleToMove = false;
       }
       }
     
    }
    public void StopAttacking() => IsAttack = false;
      public void UseAttack()
    {
        OnAttack?.Invoke();
    }
    public void Reload()
    {
        
       //_ableAttack = true;
       //  Timer = Timer + Time.deltaTime;
         // if (Timer > 1)
        //  {
              PlayerInterface.ActiveSkill();
                CurrentTime ++;
              ResultTime = CoolDownTime - CurrentTime;
            if(CurrentTime > CoolDownTime)
            {
                _ableAttack =false;
                      IsReloading = true;
                CurrentTime = 0;
                  IsCoolDown = false;
                PlayerInterface.DisactiveSkill();
            }
             else
          {
              PlayerInterface.ActiveSkill();
              _ableAttack = true;
           //   IsReloading = false;
          }
           Timer = 0;
           
         // }
         
       // StartCoroutine(Reload());
    }
     public  Enemy FindClosestEnemy() {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Enemy enemy in _enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                ClosestEnemy = enemy;
                distance = curDistance;
            }
        }
        return ClosestEnemy;
     }
     private void OnTriggerStay2D(Collider2D other) {
         if (other.TryGetComponent<Enemy>(out Enemy enemy))
         {
             _isTouchingEnemy  =true;
             ClosestEnemy = enemy;

         }
     }
     private void OnTriggerExit2D(Collider2D other) {
          if (other.TryGetComponent<Enemy>(out Enemy enemy))
         {
           // enemy.IEnemyHealth.TakeDamage(enemy.Player.Damage);
             _isTouchingEnemy  =false;
             ClosestEnemy = null;

         }
     }
     private void StartToAttack()
     {
       //FindClosestEnemy();
              UseAttack();
          ClosestEnemy.IEnemyHealth.TakeDamage(ClosestEnemy.Player.Damage);
     }
      public IEnumerator CoolDownAttack()
    {
        _ableToFight = false;
        yield return new WaitForSeconds(_waitTime);
        _ableToFight = true;
    }

    public void SetPlayer(Player player)
    {
        Player = player;
    }
     public IEnumerator CoolDown()
    {
       // IsCoolDown = true;
        yield return new WaitForSeconds(_waitTime);
      //  IsCoolDown = false;
    }
      public void StartReload()
    {
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
    }
}
