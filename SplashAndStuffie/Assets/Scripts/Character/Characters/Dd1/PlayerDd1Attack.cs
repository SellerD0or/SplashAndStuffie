using System.Net.Mime;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDd1Attack : MonoBehaviour, IPlayerAttackable
{
    public bool IsStopped { get ; set; }
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private List<PlayerDd1ShotPosition> _shotPositions;
    [SerializeField] private BulletPlayerDd1 _bullet;
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
    public event UnityAction OnAttack;
    public event UnityAction OnPressE;
    private void OnEnable() {
         IsCoolDown = false;
     }
    private void Start() {
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
     //  Reload();
       }

    }
       public void Reload()
    {
        Debug.LogError("RELOAD BULLETS + " + CountOfBullets);
           // Timer = Timer + Time.deltaTime;
         // if (Timer > 1)
         // {
               if(CountOfBullets <= 3)
        {
            
              CurrentTime ++;
              if (CoolDownTime >= CurrentTime)
              {
                  ResultTime = CoolDownTime - CurrentTime;
                  Debug.LogError(ResultTime + " COOL DD1 ATTACK!!!");
              }
            if(CurrentTime >= CoolDownTime)
            {
                IsReloading = true;
                 CountOfBullets++;
                 PlayerInterface.DisactiveSkill();
                CurrentTime = 0;
            }
               else
        {
            PlayerInterface.ActiveSkill();
            IsReloading = false;
        }
        //   Timer = 0;
        //}
     
        }
    }
    public void Attack()
    {
        if(!IsCoolDown)
        {
        if (Input.GetKeyDown(KeyCode.E) && CountOfBullets > 1)
        {
          OnPressE?.Invoke();
          CountOfBullets--;
          IsReloading = false;
         // CountOfBullets--;

         IsAttack = true;
          Invoke(nameof(StopAttacking),1.3f);
       StartCoroutine(CoolDown());
       
        }
        }
                else if(!Input.GetKeyDown(KeyCode.E) && CountOfBullets > 0)
        {
            //IsAttack =false;
        }
       
    }
        public void StopAttacking() => IsAttack = false;
    public IEnumerator CoolDown()
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _enemies = FindObjectsOfType<Enemy>();
        FindClosestEnemy();
          foreach (var shotPosition in _shotPositions)
            {
                   BulletPlayerDd1 bullet =   Instantiate(_bullet,shotPosition.transform.position , Quaternion.identity);
          bullet.SetPlayer(_player);
          
        // 
          bullet.StartMove(shotPosition.Direction);
           if(Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30)
           bullet.AbleToMove = false;
            }
        IsCoolDown = false;
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
        if(_player is Dd1)
        {
            Test test = GetComponent<Test>();
            Invoke(nameof(Reload),test.TimeForShoot );
        }
        else
        {
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
        }
    }
}
