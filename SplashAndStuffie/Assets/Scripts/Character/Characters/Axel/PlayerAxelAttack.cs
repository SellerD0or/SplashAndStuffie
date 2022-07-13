using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAxelAttack : MonoBehaviour, IPlayerAttackable
{
    public bool IsStopped { get ; set; }
     [SerializeField] private float _waitTime = 20;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private PlayerAxelSphereBullet _bullet;
    private Player _player;

    public bool IsAttack { get ; set ; }
    public bool IsCoolDown {get;set;}
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public int CountOfBullets { get => _countOfBullets; set => _countOfBullets = value; }
    public Enemy ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }
    public float CoolDownTime { get => _coolDown; set => _coolDown = value; }
    public float Timer { get ; set; }
    public float CurrentTime { get ; set ; }
    [SerializeField] private float _resultTime;
    public float ResultTime { get => _resultTime ; set => _resultTime = value; }
    public bool IsReloading { get ; set ; } = true;
    public PlayerInterface PlayerInterface { get ; set; }

    [SerializeField] private float _coolDown = 1.5f;
   [SerializeField] private int _countOfBullets = 3;
   private Enemy[] _enemies;
     private Enemy _closestEnemy;
    private bool _ableAttack =false;

    public event UnityAction OnAttack;

    private void Start() {
      
        PlayerInterface = FindObjectOfType<PlayerInterface>();
        //StartCoroutine(Reload());
    }
 
    private void Update()
     {
          if(IsStopped == false)
      {
        Attack();
      }
          if(!IsReloading)
        {
     //   Reload();
        }
    }
       public void Reload()
    {
       // Timer = Timer + Time.deltaTime;
       ///   if (Timer > 1)
        //  {
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
        //   Timer = 0;
        //  }
    }
    public void Attack()
    {
        if(!IsCoolDown )
        {

        if (Input.GetKeyDown(KeyCode.E) && !_ableAttack)
        {
            IsReloading = false;
         // CountOfBullets--;
         IsAttack = true;
         IsCoolDown = true;
               _player.IPlayerMovement.IsAttacking = true;
                              _player.IPlayerMovement.AbleToMove = true;
               _player.Rigidbody2D.velocity = Vector2.zero;
PlayerInterface.ActiveSkill();
              _ableAttack = true;  
       Debug.LogError(_player.IPlayerMovement.IsAttacking + " AXEL MUST BE STOP!!!");
                 Invoke(nameof(CreateBullet),1);
         //   StartCoroutine(CoolDown());
        }
        }
                else if(!Input.GetKeyDown(KeyCode.E))
        {
            IsAttack =false;
        }
       
    }
    public IEnumerator CoolDown()
    {
        IsCoolDown = true;
        Invoke(nameof(CreateBullet),1);
        yield return new WaitForSeconds(WaitTime);
       // _enemies = FindObjectsOfType<Enemy>();
      //  FindClosestEnemy();
       
         // foreach (var shotPosition in _shotPositions)
         //   {
         //          BulletPlayerDd1 bullet =   Instantiate(_bullet,shotPosition.transform.position , Quaternion.identity);
       //   bullet.SetPlayer(_player);
          
        // 
       //   bullet.StartMove(shotPosition.Direction);
          // if(Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30)
           //bullet.AbleToMove = false;
          //  }
        IsCoolDown = false;
    }
    private void CreateBullet()
    {
         PlayerAxelSphereBullet playerAxelBullet =  Instantiate(_bullet,_shotPosition.position,Quaternion.identity);
    playerAxelBullet.SetPlayer(_player);
                _player.IPlayerMovement.IsAttacking = false;
            _player.IPlayerMovement.AbleToMove = false;
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
        _player = player;
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
