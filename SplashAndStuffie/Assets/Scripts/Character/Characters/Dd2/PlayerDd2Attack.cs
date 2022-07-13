using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDd2Attack : MonoBehaviour, IPlayerAttackable
{
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
    public bool IsStopped { get ; set; }

    [SerializeField] private float _coolDown = 1.5f;         
     private bool _ableAttack =false;
     private PlayerDd2Animator _playerAnimator;
     private bool _touchCoolDown;
        [SerializeField]  private int _jumpDamage = 3;
        private int _countOfJumping;

    public event UnityAction OnAttack;

    private void Start() {
         _playerAnimator = GetComponent<PlayerDd2Animator>();
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
      public void UseAttack()
    {
        OnAttack?.Invoke();
    }
    public void Attack()
    {
        
      // if(!IsCoolDown)
       //{ 
       if (Input.GetKeyDown(KeyCode.E) && _countOfJumping >= 3)//&& !_ableAttack)
       {
           _enemies = FindObjectsOfType<Enemy>();
        FindClosestEnemy();
            IsReloading = false;
        if (Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30f)
        {
             _player.IPlayerMovement.IsAttacking = true;
               _player.IPlayerMovement.AbleToMove = true;
               _player.Rigidbody2D.velocity = Vector2.zero;
               _playerAnimator.CanMove = true;
                   IsAttack = true;
                   Debug.LogError(IsAttack + " Everything is ok");
                   _playerAnimator.MakeJumpSound();
           StartCoroutine(Jump());
           StartCoroutine(CoolDown());
         //  StartCoroutine(Reload());
        }
        _countOfJumping = 0;
           
       }
       else if(!Input.GetKeyDown(KeyCode.E))
       {
           IsAttack = false;
            _player.IPlayerMovement.IsAttacking = false;
              _player.IPlayerMovement.AbleToMove = false;
       }
      // }
     
    }
    public void Reload()
    {
        
       //_ableAttack = true;
        // Timer = Timer + Time.deltaTime;
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
          // Timer = 0;
           
         // }
         
       // StartCoroutine(Reload());
    }
    private void OnEnable() {
     // PlayerInterface. Skill.SetBool("Appear", false);
    }
    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(3f);
       IsJumping = true;
         Vector3 direction = ClosestEnemy.transform.position - transform.position;
            Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
       // Invoke(nameof(Land), 2f);
       
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<Enemy>(out Enemy enemy)&& !_playerAnimator.CanMove && _touchCoolDown == false)
        {
            if(_countOfJumping < 3)
            {
            _countOfJumping++;
            }
            Player.Ability.ReloadAmount(0.3f);
               UseAttack();
            enemy.IEnemyHealth.TakeDamage(_jumpDamage);
            //_player.Ability.Reload();
                        _touchCoolDown = true;
                        Invoke(nameof(Touch),2);
        }
    }
    private void Touch()
    {
        _touchCoolDown = false;
    }
    private void Land() => _isJumping = false;
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
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
    }
}
