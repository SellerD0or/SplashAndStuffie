using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(EnemyShamanAttack))]
[RequireComponent(typeof(EnemyWarriorAnimator))]
[RequireComponent(typeof(EnemyWarriorHealth))]
[RequireComponent(typeof(EnemyShamanMovement))]
[RequireComponent(typeof(EnemyShamanAnimator))]
[RequireComponent(typeof(EnemyWarriorHealthOutPut))]
[RequireComponent(typeof(ChangerState))]
public class Shaman : Enemy
{
      [SerializeField] private int _damage;
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _attackDistance = 5f;
    public override Player Player { get; set; }
  
    
    public override IEnemyAttackable  IEnemyAttackable{get;set;}
    public override IEnemyMovement IEnemyMovement { get; set; }
    public override int Damage { get => _damage; set => _damage = value; }
    public override float Speed { get => _speed; set => _speed = value; }
    public override float AttackDistance { get => _attackDistance; set => _attackDistance = value; }
    public override IEnemyHealth IEnemyHealth { get ; set ; }
    public override TakerDamageVisitor Visitor {get;set;}
    public override GetterPlayer GetterPlayer { get ; set; }
    public override IEnemyAnimator IEnemyAnimator { get ; set ; }
      [SerializeField] private float _maxDistance;
      public override IEnemyOutPut IEnemyOutPut { get ; set; }
    public override float MaxDistance { get => _maxDistance; set => _maxDistance = value; }
    private List<Enemy> _enemies = new List<Enemy>();

        private void Start() 
    {
         

        IEnemyOutPut = GetComponent<EnemyWarriorHealthOutPut>();
        IEnemyAnimator = GetComponent<EnemyShamanAnimator>();
         IEnemyHealth = GetComponent<EnemyWarriorHealth>();
        GetPlayer();
        IEnemyAttackable = GetComponent<EnemyShamanAttack>();
        IEnemyMovement = GetComponent<EnemyShamanMovement>();
         GetterPlayer.OnDestroy += GetPlayer;
         StartCoroutine(Find());
    }
       public override void Accept(IVisitor visitor)
    {
        visitor.Visit(Player);
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) && IsBewitched)
        {
            if(_enemies.Contains(enemy) == false)
            {
            enemy.IsBewitched = true;
            _enemies.Add(enemy);
            }
        }
    }
  

    public override bool CanAttack()
    {
       return Vector2.Distance(transform.position, Target.transform.position) < AttackDistance;
    }
        public override void GetPlayer()
    {
        Player = GetterPlayer.CreatedPlayer;
    }
}
