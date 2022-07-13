using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBombThrowerBulletFreeMode : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;
    public EnemyInformationFreeMode Enemy { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool AbleToMove { get => _ableToMove; set => _ableToMove = value; }
    public bool IsEnemyBullet { get => _isEnemyBullet; set => _isEnemyBullet = value; }
    public GeneratorFreeMode Generator { get => _generator; set => _generator = value; }

    private GeneratorFreeMode _generator;
    private event UnityAction<float> OnDestroy; 
    private PlayerInformationFreeMode[] _players;
    private PlayerInformationFreeMode _closestPlayer;
    private EnemyInformationFreeMode _closestEnemy;
    private bool _isCoolDown;
    private bool _canMove;
    private Vector3 _startPosition = new Vector3();
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _randomDirection;
    private bool _ableToMove = true;
    private bool _isEnemyBullet;
    private void Start() {
        
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
       // if(!AbleToMove)
       // {
      //  }
       // if(!_canMove && !AbleToMove)
       // {
         if(Enemy.IsBewitched == false && Enemy.IsByPlayerControl == false)
         {
           if(_isEnemyBullet)
           {
             Vector3 direction = _closestPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90);
        transform.position = Vector3.MoveTowards(transform.position, _closestPlayer.transform.position, _speed * Time.deltaTime);
           }
           else
           {
                transform.position = Vector3.MoveTowards(transform.position, _generator.transform.position, _speed * Time.deltaTime);
        Vector3 direction = _generator.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90);
           }
         }
         else if(Enemy.IsBewitched || Enemy.IsByPlayerControl)
         {
                        Vector3 direction =  _closestEnemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90);
        transform.position = Vector3.MoveTowards(transform.position, _closestEnemy.transform.position, _speed * Time.deltaTime);

         }
     //   }
        //else
       // {
         
        
         //   _rigidBody.velocity = _startedVector * _speed * 50 * Time.deltaTime;
       // }
       
        //_rigidbody2d.velocity = Vector2.right * Speed;
    }
   public IEnumerator CoolDown(float waitTime)
    {
       // _enemies = FindObjectsOfType<EnemyInformationFreeMode>();
       if(Enemy.IsBewitched == false && Enemy.IsByPlayerControl == false)
       {
        FindClosestPlayer();
       }
       else if(Enemy.IsBewitched || Enemy.IsByPlayerControl)
       {
         FindClosestEnemy();
       }
        yield return new WaitForSeconds(waitTime);
    }
     public  PlayerInformationFreeMode FindClosestPlayer() {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (PlayerInformationFreeMode enemy in Enemy.PlaceRow.Players) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                _closestPlayer = enemy;
                distance = curDistance;
            }
        }
        return _closestPlayer;
     }
      public  EnemyInformationFreeMode FindClosestEnemy() {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (EnemyInformationFreeMode enemy in Enemy.PlaceRow.Enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                _closestEnemy = enemy;
                distance = curDistance;
            }
        }
        return _closestEnemy;
     }

    public void SetEnemy(EnemyInformationFreeMode enemy)
    {
        Enemy = enemy;  
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
         if(Enemy.IsBewitched == false && Enemy.IsByPlayerControl == false)
       {
          if(_isEnemyBullet)
          {
           if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode player))
           {
          if(Enemy.PlaceRow.Players.Contains(player))
          {
          Debug.LogError(player);
          player.PlayerMovementFreeMode.PlayerHealth.TakeDamage(Enemy.Damage);
          OnDestroy?.Invoke(0);
          }
            }
          }
          else
          {
                if (other.TryGetComponent<GeneratorFreeMode>(out GeneratorFreeMode generator))
           {
               generator.TakeDamage(Enemy.Damage,Enemy);
          OnDestroy?.Invoke(0);
            }
          }
       }
       else  if(Enemy.IsBewitched || Enemy.IsByPlayerControl)
       {
           if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
           {
          if(Enemy.PlaceRow.Enemies.Contains(enemy))
          {
          enemy.EnemyAttack.EnemyHealth.TakeDamage(Enemy.Damage);
          OnDestroy?.Invoke(0);
          }
            }
       }
  }
  private void Destroy(float waitTime)
  {
      Destroy(gameObject, waitTime);
  }
}
