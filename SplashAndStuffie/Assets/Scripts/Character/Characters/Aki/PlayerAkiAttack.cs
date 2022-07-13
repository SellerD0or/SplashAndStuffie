using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAkiAttack : MonoBehaviour, IPlayerAttackable
{
  public bool IsStopped { get ; set; }
      [SerializeField] private Transform _shotPosition;
    [SerializeField] private PlayerAkiBullet _bullet;

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
    [SerializeField] private int _maxHealthForHealing = 75;
    [SerializeField] private int _percentOfAdditionHealth;
    [SerializeField] private float _coolDown = 1.5f;         
     private bool _ableAttack =false;
     private GetterPlayer _getterPlayer;

    public event UnityAction OnAttack;

    private void OnEnable() {
            _player.IPlayerMovement.AbleToMove = false;
     }
     private void Start() {
                _getterPlayer =FindObjectOfType<GetterPlayer>();

         PlayerInterface = FindObjectOfType<PlayerInterface>();
     }
    private void Update() {
       if(IsStopped == false)
      {
        Attack();
      }
        if(!IsReloading)
        {
       // Reload();
        }
    }
    public void Attack()
    {
        
       if(!IsCoolDown)
       { 
       if (Input.GetKeyDown(KeyCode.E) && !_ableAttack)
       {
         /*  foreach (var player in PlayerInterface.GetterPlayer.Players)
           {
               if (player.PlayerHealth.Health <= player.PlayerHealth.MaxHealth * _maxHealthForHealing / 100 && player.IsDead == false)
               {
               player.PlayerHealth.Health += player.PlayerHealth.MaxHealth * _percentOfAdditionHealth /100;
             HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == player.Name);

              healthOutput?.TakeDamage();         
               }
           }*/ 
                IsAttack = true;
               _player.IPlayerMovement.AbleToMove = true;
               _player.Rigidbody2D.velocity = Vector2.zero;
           Invoke(nameof(CreateBullet),1f);
           IsReloading = false;
        //   _enemies = FindObjectsOfType<Enemy>();
      //  FindClosestEnemy();
      //  if (Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30f)
      // {
           // _player.IPlayerMovement.IsAttacking = true;
                 //  Debug.LogError(IsAttack + " Everything is ok");
          
           StartCoroutine(CoolDown());
         //  StartCoroutine(Reload());
       // }
           
       }
       else if(!Input.GetKeyDown(KeyCode.E))
       {
           IsAttack = false;
             // _player.IPlayerMovement.AbleToMove = false;

         //   _player.IPlayerMovement.IsAttacking = false;
       }
       }
     
    }
     private void CreateBullet()
    {
         PlayerAkiBullet playerAkiBullet =  Instantiate(_bullet,_shotPosition.position,Quaternion.identity);
    playerAkiBullet.SetPlayer(_player);
    IsAttack = false;
    Invoke(nameof(ContinieToMove), 0.5f);
    }
    private void ContinieToMove() =>       _player.IPlayerMovement.AbleToMove = false;
    public void Reload()
    {
        
       //_ableAttack = true;
         //Timer = Timer + Time.deltaTime;
        //  if (Timer > 1)
        //  {
              PlayerInterface.ActiveSkill();
                CurrentTime ++;
              ResultTime = CoolDownTime - CurrentTime;
            if(CurrentTime > CoolDownTime)
            {
                _ableAttack =false;
                CurrentTime = 0;
                PlayerInterface.DisactiveSkill();
                IsReloading = true;
            }
             else
          {
              _ableAttack = true;
              PlayerInterface.ActiveSkill();
           //   IsReloading = false;
          }
        //   Timer = 0;
           
        //  }
         
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


    public void SetPlayer(Player player)
    {
        Player = player;
    }
     public IEnumerator CoolDown()
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(_waitTime);
        IsCoolDown = false;
    }

    public void StartReload()
    {
        Invoke(nameof(Reload),Player.IPlayerAnimator.TimeForShoot);
    }

    public void UseAttack()
    {
        OnAttack?.Invoke();
    }
}
