using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(TakerDamageVisitor))]
[RequireComponent(typeof(PlayerBomberMovement))]
[RequireComponent(typeof(CharacterChangerState))]
[RequireComponent(typeof(PlayerBomberAnimator))]
[RequireComponent(typeof(PlayerDd1Attack))]
[RequireComponent(typeof(PlayerBomberAbility))]
public class Bomber : Player, IDamageable
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _iconAbility;
    [SerializeField] private Sprite _iconSkill;
   [SerializeField] private Sprite _barIcon;
       [SerializeField] private Sprite _icon;
    [SerializeField] private Rigidbody2D _rigidBody2d;
    [SerializeField] private float _speed;
    private TakerDamageVisitor _takerDamage;
    [SerializeField] private int _damage = 5;
    public override PlayerHealth PlayerHealth { get; set; }
    public override Enemy Enemy{get;set;}
    public override int Damage { get => _damage; set => _damage = value; }
    public override TakerDamageVisitor TakerDamageVisitor {get;set;}
     public override Rigidbody2D Rigidbody2D {get => _rigidBody2d;set => _rigidBody2d = value;}
    public override  float Speed {get => _speed;set => _speed = value;}
    public override IPlayerMovement IPlayerMovement { get; set; }
    public override IPlayerAttackable IPlayerAttackable { get ; set ; }
    public override CharacterChangerState CharacterChangerState { get ; set ; }
    public override IPlayerAnimator IPlayerAnimator { get ; set ; }
    public override Sprite Icon { get => _icon; set => _icon = value; }
    public override IHealthOutPut IHealthOutPut { get; set; }
    public override Sprite BarIcon { get => _barIcon; set => _barIcon = value; }
    public override Sprite IconAbility { get => _iconAbility; set => _iconAbility = value; }
    public override Sprite IconSkill { get => _iconSkill; set => _iconSkill = value; }
    public override string Name { get => _name; set => _name = value; }
     public override Ability Ability { get ; set ; }

    private void Awake() {
        Ability = GetComponent<PlayerBomberAbility>();
        IPlayerAttackable = GetComponent<PlayerDd1Attack>();
        IPlayerAttackable.SetPlayer(this);
        IPlayerAnimator = GetComponent<PlayerBomberAnimator>();
        CharacterChangerState = GetComponent<CharacterChangerState>();
        IPlayerMovement = GetComponent<PlayerBomberMovement>();
       PlayerHealth = GetComponent<PlayerHealth>();
       IHealthOutPut = FindObjectOfType<Dd1HealthOutPut>();
    }
      private void Update() {
      if(IsInFreeMode == false)
      {
        IPlayerMovement.Move(this);
      }
    }

    public void Accept(IVisitor visitor)
    {
       visitor.Visit(this);
    }

    private void OnTriggerStay2D(Collider2D other) {
     //   if (other.TryGetComponent<Enemy>(out Enemy enemy))
    //    {
      //      Debug.Log("SSSS");
     //      Enemy = enemy;
         //  enemy.EnemyHealth.TakeDamage(Damage);
     //   }
    }

    public override bool IsMove()
    {
      return  IPlayerMovement.TargetVelocity != Vector2.zero;
    }

    public override bool IsAttack()
    {
       return IPlayerAttackable.IsAttack;
    }


}
