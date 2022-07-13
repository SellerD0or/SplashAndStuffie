using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class PlayerMummyHatAbility : Ability
{
    [SerializeField] private float _coolDown;
    [SerializeField] private ParticleSystem _particleSystem;
    public override float CoolDown { get => _coolDown; set => _coolDown = value; }
    public override Player Player { get; set ; }
    public override bool IsCoolDown { get ; set ; } = true;
    public override ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }
    [SerializeField] private float _lastedTime;
    public override float LastedTime { get => _lastedTime; set => _lastedTime = value; }
       [SerializeField] private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private int _percentOfAdditionHealth = 35;
         private Enemy[] _enemies;
         public Enemy ClosestEnemy { get; set; }
     private float _timer = 0;
     private bool _isMovingToClosestEnemy;
     private bool _isAbilityUsed;
          private IPlayerMovement _movement;
          private UnityArmatureComponent _animator;
          private Enemy _witchedEnemy;
          private PlayerHealth _playerHealth;
     private void Start() {
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
    }
    private void OnEnable() {
        if (_animator == null)
        {
            _animator= GetComponent<UnityArmatureComponent>();
        }
        if (_playerHealth == null)
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }
       Active();
       ParticleSystem.Stop();
       ContinieToMove();
    
    }

    private void Update() {
                if(IsStoppeUsingAbility == false)
        {
        if (Input.GetKeyDown(KeyCode.Q) && IsCoolDown)
        {
          IsCoolDown = false;
         ParticleSystem.Play();
         UseAbilitiy();
        }
        

        if (!IsCoolDown)
        {
            ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -4.6f : 4.6f,ParticleSystem.transform.localScale.y, ParticleSystem.transform.localScale.z); 
     /*       _timer = _timer + Time.deltaTime;
         LastedTime = CoolDown - CurrentTime;
          if (_timer > 1)
          {
              CurrentTime ++;
              LastedTime = CoolDown - CurrentTime;
                 if (CurrentTime > Player.Ability.TimeForRemovingAbility)
             {
                 Player.Ability.DisactiveAbility();
             }
            if(CurrentTime > CoolDown)
            {
                 DisactiveAbility();
                IsCoolDown = true;
                CurrentTime = 0;
            }
           _timer = 0;
          }*/
        }
        }

        if (_isMovingToClosestEnemy == true)
        {
            Debug.Log("MOVING MUMMY HAT!!!");
            transform.position = Vector3.MoveTowards(transform.position,ClosestEnemy.transform.position,Player.Speed * 10 * Time.deltaTime);
            if (Vector2.Distance(ClosestEnemy.transform.position,transform.position) < 0.5f && _isAbilityUsed == false)
            {
            Disactive();
               ContinieToMove();
               ClosestEnemy.OnDestroyed += ClosestEnemy.RemoveWitching;
               ClosestEnemy.OnDestroyed += Active;
               if (_witchedEnemy !=null)
               {
                           RemoveWitchingOfEnemy();
               }
               _witchedEnemy = ClosestEnemy;
               ClosestEnemy.IsBewitched = true;
               ClosestEnemy.IsUnderPlayerControl = true;
             _isAbilityUsed = true;
            }
        }
    }

    public override void UseAbilitiy()
    {
        _playerHealth.AdditionShield = 0;
       Debug.Log("Mummy hat");
       _isAbilityUsed =false;
         _movement.AbleToMove = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       _enemies =FindObjectsOfType<Enemy>();
       FindClosestEnemy();
       _isMovingToClosestEnemy = true;
                Player.Ability.DestroyAbility();
            //    Invoke(nameof(Disactive),2);
        
    }
    private void Disactive()
    {
        _animator.sortingOrder = -1202;
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
      private void ContinieToMove()
    {
      if(_movement == null)
      {
        _movement =GetComponent<PlayerDd1Movement>();
      }
     _movement.AbleToMove = false;
    }
    public override IEnumerator Reload()
    {
        IsCoolDown = false;
        ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -10 : 10,ParticleSystem.transform.localScale.x, 0); 
        ParticleSystem.Play();
        UseAbilitiy();
        yield return new WaitForSeconds(CoolDown);
        DisactiveAbility();
        IsCoolDown = true;
    }

    public override void DisactiveAbility()
    {
        
        _playerInterface.DisactiveAbility();
    }
    private void Active()
    {
        _animator.sortingOrder = 0;
                _playerHealth.AdditionShield = 1;
    }
    public override void RemoveAbility()
    {
        _isMovingToClosestEnemy = false;
        _witchedEnemy.IsBewitched = false;
        RemoveWitchingOfEnemy();
        _witchedEnemy.RemoveWitching();
        _isAbilityUsed = false;
        Active();
    }
    private void  RemoveWitchingOfEnemy()
    {  
          _witchedEnemy.OnDestroyed -= _witchedEnemy.RemoveWitching;
        _witchedEnemy.OnDestroyed -= Active;
    }
}
