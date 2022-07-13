using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyWarriorAttack))]
[RequireComponent(typeof(EnemyWarriorMovement))]
[RequireComponent(typeof(EnemyWarriorHealth))]
[RequireComponent(typeof(EnemyWarriorAnimator))]
[RequireComponent(typeof(EnemyWarriorHealthOutPut))]
[RequireComponent(typeof(ChangerState))]
public class Warrior : Enemy
{
    
     [SerializeField] private int _damage;
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _attackDistance = 5f;
    public override Player Player { get; set; }
   public override int Damage { get => _damage; set => _damage = value; }
    public override float Speed { get => _speed; set => _speed = value; }
    public override float AttackDistance { get => _attackDistance; set => _attackDistance = value; }
    public override IEnemyAttackable  IEnemyAttackable{get;set;}
    public override IEnemyMovement IEnemyMovement { get; set; }
    public override IEnemyHealth IEnemyHealth { get ; set ; }
    public override TakerDamageVisitor Visitor {get;set;}
    public override GetterPlayer GetterPlayer { get ; set; }
    public override IEnemyAnimator IEnemyAnimator { get ; set ; }
      [SerializeField] private float _maxDistance;
    public override float MaxDistance { get => _maxDistance; set => _maxDistance = value; }
    public override IEnemyOutPut IEnemyOutPut { get ; set; }

    private void Start() 
    {
        IEnemyOutPut = GetComponent<EnemyWarriorHealthOutPut>();
        IEnemyAnimator = GetComponent<EnemyWarriorAnimator>();
        IEnemyHealth = GetComponent<EnemyWarriorHealth>();
       GetPlayer();
        IEnemyAttackable = GetComponent<EnemyWarriorAttack>();
        IEnemyMovement = GetComponent<EnemyWarriorMovement>();
         GetterPlayer.OnDestroy += GetPlayer;
                StartCoroutine(Find());

    }
       public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override bool CanAttack()
    {
       // if(IEnemyAttackable.IsStayed)
       // {
       //     return false;
       // }
       // else
       // {
       return Vector2.Distance(transform.position, Target.transform.position) < AttackDistance;
       // }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) && IsBewitched)
        {
            if(Enemies.Contains(enemy) == false && enemy != this)
            {
            enemy.IsBewitched = true;
            Debug.Log(enemy + " IS BEWITCHED!!!");
            Enemies.Add(enemy);
            }
        }
    }
   
    public override void GetPlayer()
    {
        Player = GetterPlayer.CreatedPlayer;
    }
    

    
}
