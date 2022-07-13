using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
public class PlayerTattiAbility : Ability
{
    [SerializeField] private UnityArmatureComponent _healEffect;
    [SerializeField] private float _range = 5;
    [SerializeField] private GameObject _eatPosition;
    private Enemy _closestEnemy;
        public Enemy ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }
private Enemy[] _enemies;
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
    public UnityArmatureComponent HealEffect { get => _healEffect; set => _healEffect = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private float _percentOfAdditionSpeed = 1.35f;
    [SerializeField] private PlayerTattiAnimator _animator;
     private float _timer = 0;
     private float _timeForBit;
     private bool _isBitten ;
     private PlayerTattiAttack _tattiAttack;
     private void Start() {
       _tattiAttack = GetComponent<PlayerTattiAttack>();
       HealEffect.gameObject.SetActive(false);
         HealEffect.animation.Stop();
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
    }
    private void OnEnable() {
       
        ParticleSystem.Stop();
    
    }

    private void Update() {
         if(IsStoppeUsingAbility == false)
        {
        if (Input.GetKeyDown(KeyCode.Q)&& IsCoolDown)
        {
         
         UseAbilitiy();
        }
        if (_isBitten)
        {
          Bit();  
        }
        ActiveAbility();
        }
       
    }
    private void ActiveAbility()
    {
         if (!IsCoolDown)
        {
            ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? 4.6f : -4.6f,ParticleSystem.transform.localScale.y, ParticleSystem.transform.localScale.z); 
         /*   _timer = _timer + Time.deltaTime;
         LastedTime = CoolDown - CurrentTime;
          if (_timer > 1)
          {
              CurrentTime ++;
              LastedTime = CoolDown - CurrentTime;
                 if (CurrentTime > Player.Ability.TimeForRemovingAbility && IsAbilityRemoved== false)
             {
                 IsCoolDown = false;
                 IsAbilityRemoved = true;
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

    public override void UseAbilitiy()
    {
       
            Player.IPlayerMovement.AbleToMove = true;
          Player.IPlayerMovement.IsAttacking = true;
              Player.Rigidbody2D.velocity = Vector2.zero;
              _tattiAttack.StartMove(2);
              _animator.IsEating = true;
       FindClosestEnemy();
       if (Vector3.Distance(_eatPosition.transform.position, _closestEnemy.transform.position) < _range)
       {
            IsCoolDown = false;
         ParticleSystem.Play();
           _playerInterface.ActiveAbility();
           _isBitten = true;
             IsAbilityRemoved = false;
       _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {Player.Ability.CoolDown}";

         //  StartCoroutine(Bit());
       }

       
         Player.Ability.DestroyAbility();

    }
    private void Bit()
    {
        _timeForBit+= Time.deltaTime;
        if(_timeForBit >= 4)
        {
      //  yield return new WaitForSeconds(4);
        if (Player.PlayerHealth.MaxHealth * 98 / 100 >= Player.PlayerHealth.Health)
                {
                  HealEffect.gameObject.SetActive(true);
                    HealEffect.animation.Play("tatti_heal");
                            Player.PlayerHealth.Health += Player.PlayerHealth.MaxHealth * 2 / 100;
                            Player.IHealthOutPut.HealthOutput.TakeDamage();
               }
               if(IsCoolDown)
               {
                 HealEffect.gameObject.SetActive(false);
                   HealEffect.animation.Stop();
                 _isBitten = false;
               }
               _timeForBit = 0;
        }
    }
      public  Enemy FindClosestEnemy() {
          _enemies = FindObjectsOfType<Enemy>();
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

    public override void RemoveAbility()
    {
//        throw new System.NotImplementedException();
    }
}
