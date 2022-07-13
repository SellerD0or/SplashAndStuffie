using System.Net.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTattiAttack : MonoBehaviour, IPlayerAttackable
{
     public bool IsStopped { get ; set; } 
     private Player _player;
     [SerializeField] private float _waitTime = 4f;
     private Enemy[] _enemies;
     private Enemy _closestEnemy;
    public bool IsAttack { get ; set ; }
    public bool IsCoolDown {get;set;}
      public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public Player Player { get => _player; set => _player = value; }
    public float Angle { get => _angle; set => _angle = value; }
    public Enemy ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }

    private float _angle;
  public float CoolDownTime { get => _coolDown; set => _coolDown = value; }
    public float Timer { get ; set; }
    public float CurrentTime { get ; set ; }
    public float ResultTime { get ; set ; }
    public bool IsReloading { get; set ; } = true;
    public PlayerInterface PlayerInterface { get ; set; }

    [SerializeField] private PlayerTattiRoar _roar;  
    [SerializeField] private float _coolDown = 1.5f;         
     private bool _ableAttack =false;
     private PlayerDd2Movement _movement;
     [SerializeField] private float _range =2;
     [SerializeField] private LayerMask _layer;

    public event UnityAction OnAttack;
    private void Awake() {
         _movement = GetComponent<PlayerDd2Movement>();
         PlayerInterface = FindObjectOfType<PlayerInterface>();
     }
     private void OnEnable() {
       if (_player.IPlayerMovement == null)
       {
         _player.IPlayerMovement = GetComponent<IPlayerMovement>();
       }
       ContinieToMove();
     }
    private void Update() {
      if(IsStopped == false)
      {
        Attack();
      }
        if(!IsReloading)
        {
       //Reload();
        }
    }
    private void MakeSchulde()
    {
      Collider2D[] collider2Ds =  Physics2D.OverlapCircleAll(transform.position, _range, _layer);
      foreach (var item in collider2Ds)
      {
          item.GetComponent<Enemy>().IEnemyHealth.TakeDamage(_player.Damage);
          UseAttack();
      }
    }
    public void Attack()
    {
        
       if(!IsCoolDown)
       { 
       if (Input.GetKeyDown(KeyCode.E) && !_ableAttack)
       {
           IsReloading = false;
           _enemies = FindObjectsOfType<Enemy>();
        FindClosestEnemy();
        IsCoolDown = true;
              _player.IPlayerMovement.AbleToMove = true;
          _player.IPlayerMovement.IsAttacking = true;
              _player.Rigidbody2D.velocity = Vector2.zero;
              _ableAttack = true;
              PlayerInterface.ActiveSkill();
          IsAttack = true;
          Invoke(nameof(StopAttacking),2.5f);
        //if (Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30f)
      //  {
            
           StartCoroutine(UseRoar());
           StartCoroutine(CoolDown());
         //  StartCoroutine(Reload());
        //}
           StartMove(3);
       }
       else if(!Input.GetKeyDown(KeyCode.E))
       {
         //  IsAttack = false;
           // _player.IPlayerMovement.IsAttacking = false;
       }
       }
     
    }
    public void StartMove(float time)=> Invoke(nameof(ContinieToMove), time);
        public void StopAttacking() => IsAttack = false;
    private void ContinieToMove()
    {
       _player.IPlayerMovement.IsAttacking = false;
            _player.IPlayerMovement.AbleToMove = false;
    }
    public void Reload()
    {
        
       //_ableAttack = true;
     //    Timer = Timer + Time.deltaTime;
         // if (Timer > 1)
        //      if(!IsReloading)
           CurrentTime ++;
              if (CoolDownTime >= CurrentTime)
              {
                  ResultTime = CoolDownTime - CurrentTime;
              }
            if(CurrentTime >= CoolDownTime)
            {
                IsCoolDown = false;
                _ableAttack =false;
                IsReloading = true;
                 PlayerInterface.DisactiveSkill();
                CurrentTime = 0;
            }
               else
        {
            PlayerInterface.ActiveSkill();
              _ableAttack = true;
        }
               
         //  Timer = 0;
           
         // }
         
       // StartCoroutine(Reload());
    }
    private IEnumerator UseRoar()
    {

        Invoke(nameof(Open),1.5f);
        yield return new WaitForSeconds(3.2f);
  
       _roar.Close();
         
       // Invoke(nameof(Land), 2f);
       
    }
    private void Open()
    {
               _roar.IsEndedCooldown = false;
                 _roar.Open();

        MakeSchulde();
        Debug.LogError("OPEN ROAR !!!");
        _roar.Collider.enabled = true;
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


    public void SetPlayer(Player player)
    {
        Player = player;
    }
     public IEnumerator CoolDown()
    {
        //        _movement.AbleToMove = true;
        IsCoolDown = true;
        yield return new WaitForSeconds(_waitTime);
        IsCoolDown = false;
         //     _movement.AbleToMove = false;
    }
      public void StartReload()
    {
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
    }

     public void UseAttack()
    {
        OnAttack?.Invoke();
    }
}
