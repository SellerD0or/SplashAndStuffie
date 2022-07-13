using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletPlayerDd1 :  PlayerBullet, IMoveableBullet
{
    [SerializeField] private Animator _animator;
     [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;
    public override Player Player { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool AbleToMove { get => _ableToMove; set => _ableToMove = value; }

    private event UnityAction<float> OnDestroy; 
    private Enemy[] _enemies;
    private Enemy _closestEnemy;
    private bool _isCoolDown;
    private bool _canMove;
    private Vector3 _startPosition = new Vector3();
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _randomDirection;
    private bool _ableToMove = true;
    [SerializeField] private bool _isDd1 = true;
    private void Start() {
        if(_isDd1)
        {
           PlayerAudioSourse playerAudioSourse = Instantiate(Player.GetComponent<Test>().PlayerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = Player.GetComponent<Test>().AudioClips[1];
           playerAudioSourse.AudioSource.Play();
        }
        OnDestroy += Destroy;
        StartCoroutine(CoolDown(1));
        OnDestroy?.Invoke(_waitTime);
        
        _rigidbody.velocity = transform.TransformDirection(new Vector3(_randomDirection,Speed / 2, 0));
        
    }
    public void StartMove(int _direction)
    {
        Debug.Log("Cool");
        _randomDirection = _direction;
       // _startPosition = startPosition.position;
//        Debug.LogError(_startPosition);
      _canMove = true;
      Invoke(nameof(ChangeCanMove), 0.5f);
    }
    private void ChangeCanMove()
    {
        _canMove = false;
    }
    
    private void Update() {
         if(!_isCoolDown)
        {
        StartCoroutine(CoolDown(5));
        }
        if(!AbleToMove)
        {
          Vector3 direction = _closestEnemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90);
        }
        if(!_canMove && !AbleToMove)
        {
        transform.position = Vector3.MoveTowards(transform.position, _closestEnemy.transform.position, _speed * Time.deltaTime);
        }
        else
        {
         
        
         //   _rigidBody.velocity = _startedVector * _speed * 50 * Time.deltaTime;
        }
       
        //_rigidbody2d.velocity = Vector2.right * Speed;
    }
   public IEnumerator CoolDown(float waitTime)
    {
        _enemies = FindObjectsOfType<Enemy>();
        FindClosestEnemy();
        yield return new WaitForSeconds(waitTime);
    }
     public  Enemy FindClosestEnemy() {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Enemy enemy in _enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                _closestEnemy = enemy;
                distance = curDistance;
            }
        }
        return _closestEnemy;
     }

    public override void SetPlayer(Player player)
    {
        Player = player;  
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
      if (other.TryGetComponent<Enemy>(out Enemy enemy))
      {
//          Debug.LogError(enemy); 
         Player.Ability.ReloadAmount(0.2f);
         Player.IPlayerAttackable.UseAttack();
          enemy.IEnemyHealth.TakeDamage(Player.Damage);
          OnDestroy?.Invoke(0);
      }
  }
  private void Destroy(float waitTime)
  {
      Destroy(gameObject, waitTime);
  }

}
