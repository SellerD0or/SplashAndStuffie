using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyRangerBullet : EnemyBullet, IMoveableBullet
{
    private Player _player;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;
    public override Enemy Enemy { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public Rigidbody2D RigidBody { get => _rigidBody; set => _rigidBody = value; }
    public Player Player { get => _player; set => _player = value; }

    private event UnityAction<float> OnDestroy; 
    [SerializeField] private Rigidbody2D _rigidBody;
    private bool _canFly;
    private float _timeForTurning;
    private void Start() {
        OnDestroy += Destroy;
        OnDestroy?.Invoke(_waitTime);
        Debug.LogError(transform.position.y + " WAdsadsada");
       _timeForTurning = (20 - transform.position.y) / (_speed * 1.25f);
       Debug.LogError(_timeForTurning + " TIME FOR TURNINH!!!");
        Invoke(nameof(TurnOnMoment),_timeForTurning * 3);
    }
    private void Update() {
       // transform.Translate(Vector3.right * Speed * Time.deltaTime);
       if(_canFly)
        _rigidBody.velocity = transform.right * Speed;
    }
    private void TurnOnMoment()
    {
        _canFly = true;
         Vector3 direction = Enemy.Target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public override void SetEnemy(Enemy enemy, Transform shotPosition)
    {
        Enemy = enemy;
        transform.rotation = shotPosition.rotation;
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
          if(Enemy.IsBewitched == false)
          {
      if (other.TryGetComponent<Player>(out Player player))
      {
        player.PlayerHealth.TakeDamage(Enemy.Damage);
          OnDestroy?.Invoke(_waitTime);
      }
          }
    else
    {
         if (other.TryGetComponent<Enemy>(out Enemy enemy))
      {
        enemy.IEnemyHealth.TakeDamage(Enemy.Damage);
          OnDestroy?.Invoke(_waitTime);
      }
    }
  }
  private void Destroy(float waitTime)
  {
      Destroy(gameObject, waitTime);
  }

}
