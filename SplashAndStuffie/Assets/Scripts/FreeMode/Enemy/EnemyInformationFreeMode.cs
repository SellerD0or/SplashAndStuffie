using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyInformationFreeMode : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private EnemyAnimtatorFreeMode _enemyAnimator;
    [SerializeField] private EnemyFire _fire;
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private GameObject _particle;
    [SerializeField] private float _health;
        public event UnityAction OnDeath;      
        public float MaxHealth { get; set; }
    public float Health { get => _health; set => _health = value; }

    [SerializeField] private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    public float StartSpeed { get; set; }
    [SerializeField] private int _damage;
        public Rigidbody2D RigidBody2D { get => _rigidBody2D; set => _rigidBody2D = value; }

    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private EnemyAttackFreeMode _enemyAttack;
  [SerializeField] private PlayerAnimatorFreeMode _playerAnimatorFreeMode;
    private Vector2 _direction;
      public Vector2 Direction { get => _direction; set => _direction = value; }

    public PlayerAnimatorFreeMode PlayerAnimatorFreeMode { get => _playerAnimatorFreeMode; set => _playerAnimatorFreeMode = value; }
    [SerializeField] private bool _isBig;
   private PlaceRowFreeMode _placeRow;
   private bool _isBewitched;
   private bool _isByPlayerControl;
   public bool CanMove { get; set; } = true;
       public bool IsBig { get => _isBig; set => _isBig = value; }
       [SerializeField] private float _range = 4;
    public PlaceRowFreeMode PlaceRow { get => _placeRow; set => _placeRow = value; }
    [SerializeField] private PlayerInformationFreeMode _closestPlayer;
    public PlayerInformationFreeMode ClosestPlayer { get => _closestPlayer; set =>_closestPlayer = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public EnemyAttackFreeMode EnemyAttack { get => _enemyAttack; set => _enemyAttack = value; }
    public EnemyAnimtatorFreeMode EnemyAnimator { get => _enemyAnimator; set => _enemyAnimator = value; }
    public string Name { get => _name; set => _name = value; }
    public bool IsBewitched { get => _isBewitched; set => _isBewitched = value; }
    public bool IsByPlayerControl { get => _isByPlayerControl; set => _isByPlayerControl = value; }
    public EnemyInformationFreeMode ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }

    private GeneratorFreeMode _generator;
    private bool _isReachedRow;
    [SerializeField] private float _rangeForGenerator = 1;
    private EnemyInformationFreeMode _closestEnemy;
    private void Start() {
        _generator = FindObjectOfType<GeneratorFreeMode>();
       // _deathEffect.Stop();
        MaxHealth = Health;
        StartSpeed = Speed;
        StartCoroutine(LookForPlayer());
    }
    private IEnumerator LookForPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        if(PlaceRow.Players.Count >= 0)
        {
        FindClosestPlayer();
        }
        if (PlaceRow.Enemies.Count >= 0 && (_isBewitched || _isByPlayerControl))
        {
            FindClosestEnemy();
        }
        StartCoroutine(LookForPlayer());
    }
    public  PlayerInformationFreeMode FindClosestPlayer() 
    {
       
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        List<PlayerInformationFreeMode> players = PlaceRow.Players;
      //  if (PlaceRow.IsTheHighestPlaceRow == false)
     //   {
      //    List<PlayerInformationFreeMode> players2 = PlaceRow.HigherPlaceRow.Players.FindAll(e=> e.IsBig == true);
      //    players.Union(players2);
      //  }
        foreach (PlayerInformationFreeMode player in players) 
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) 
            {
                ClosestPlayer = player;
                distance = curDistance;
            }
        }
        return ClosestPlayer;
    }
    private EnemyInformationFreeMode FindClosestEnemy()
    {
                float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        List<EnemyInformationFreeMode> enemies = PlaceRow.Enemies;
      //  if (PlaceRow.IsTheHighestPlaceRow == false)
     //   {
      //    List<PlayerInformationFreeMode> players2 = PlaceRow.HigherPlaceRow.Players.FindAll(e=> e.IsBig == true);
      //    players.Union(players2);
      //  }
        foreach (EnemyInformationFreeMode enemy in enemies) 
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) 
            {
                ClosestEnemy = enemy;
                distance = curDistance;
            }
        }
        return ClosestEnemy;

    }
    public bool CanAttack()
    {
        if(ClosestPlayer != null)
        {
         if(!_placeRow.IsLowPlace)
            {
        return Vector3.Distance(new Vector3( transform.position.x,0,0), new Vector3( ClosestPlayer.transform.position.x,0,0)) < _range;
            }
             else
         {
                    return Vector3.Distance(new Vector3(0,transform.position.y,0), new Vector3( 0,ClosestPlayer.transform.position.y,0)) < _range;
         }
        }
        else
        return false;
    }
    private void Update() {
        CanDestroyGenerator();
    }
    public void CanDestroyGenerator()
    {
        if (_isByPlayerControl == false && _isBewitched == false)
        {
        if(CanAttack() == false)
        {
          if(!_placeRow.IsLowPlace)
            {
        if( Vector3.Distance(new Vector3( transform.position.x,0,0), new Vector3( _generator.transform.position.x,0,0)) < _rangeForGenerator)
        {
AttackGenerator();
        }
            }
             else
         {
        if( Vector3.Distance(new Vector3(0,transform.position.y,0), new Vector3( 0,_generator.transform.position.y,0)) < _rangeForGenerator * 1.2f)
        {
AttackGenerator();
        }
         }
        }
        }
    }
     public void  Destroy()
    {
                 Instantiate(_fire,transform.position,Quaternion.identity);

      GameObject gameObject = Instantiate(_particle,transform.position,Quaternion.Euler(180,0,0));
       gameObject.transform.rotation = Quaternion.Euler(90,0,180);
      //_deathEffect.Play();
       OnDeath?.Invoke(); 
    }
    private void AttackGenerator()
    {
           EnemyAttack.AttackGenerator(_generator);
           StartSpeed = 0.0000001f;
           Speed =0.0000001f;
    }
   // private void OnTriggerStay2D(Collider2D other) {
       
          
         //if(other.TryGetComponent<GeneratorFreeMode>(out GeneratorFreeMode generator))
      // {
          //   Debug.Log("cool" +_canAttack);
            //if(_canAttack)
        //{
         
          // CanMove = false;
           
        ///   StartCoroutine(CoolDown());
        // } 
       // }
  //  }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!_isReachedRow)
        {
            if (other.GetComponent<PlaceFreeMode>())
            {
                EnemyAnimator.Attack();
                PlaceRow.StartMovingPlayer(this);
                _isReachedRow = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy) && (IsBewitched || IsByPlayerControl))
        {
            enemy.IsBewitched = true;
        }
    }
  
}
