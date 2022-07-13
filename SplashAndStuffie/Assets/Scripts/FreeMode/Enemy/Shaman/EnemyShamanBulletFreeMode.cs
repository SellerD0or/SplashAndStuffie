using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShamanBulletFreeMode : MonoBehaviour
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
    private bool _isCoolDown;
    private bool _canMove;
    private Vector3 _startPosition = new Vector3();
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _randomDirection;
    private bool _ableToMove = true;
    private bool _isEnemyBullet;
      private bool _isReached;
     public float PositionYForStop { get; set; }
    private void Start() {
        
        
        OnDestroy += Destroy;
        OnDestroy?.Invoke(_waitTime);        
    }
    
    private void Update() {
         if (transform.position.y > PositionYForStop)
      {
        Debug.LogError("move down");
          transform.Translate(Vector2.down * _speed * Time.deltaTime);
      }
      else
      {
          _isReached = true;
          Destroy(_waitTime);

      }
    }
    public void SetEnemy(EnemyInformationFreeMode enemy)
    {
        Enemy = enemy;  
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
         if( Enemy.IsBewitched ==false && Enemy.IsByPlayerControl== false)
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
      else if( Enemy.IsBewitched  || Enemy.IsByPlayerControl)
      {
          if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
          {
            enemy.EnemyAttack.EnemyHealth.TakeDamage(Enemy.Damage);
          }
      }
  }
  private void Destroy(float waitTime)
  {
      Destroy(gameObject, waitTime);
  }
}
