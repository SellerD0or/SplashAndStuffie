using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAxelSphereBullet : PlayerBullet, IMoveableBullet
{
        [SerializeField] private GameObject _electroBall;
   [SerializeField] private Animator _animator;
     [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;
    public override Player Player { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool AbleToMove { get => _ableToMove; set => _ableToMove = value; }
    public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }

    [SerializeField] private PlayerAxelBullet _bullet;
    private event UnityAction<float> OnDestroy; 
    private Enemy[] _enemies;
    private Enemy _closestEnemy;
    private bool _isCoolDown;
    private bool _canMove;
    private Vector3 _startPosition = new Vector3();
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _randomDirection;
    private bool _ableToMove = true;
    private float _rotation;
    private void Start() {
        OnDestroy += Destroy;
        OnDestroy?.Invoke(_waitTime);
        
        _rigidbody.velocity = transform.TransformDirection(new Vector3(_randomDirection,Speed / 2, 0));
    }
    private void Update()
     {  
     _rigidbody.velocity = transform.right * _speed;   
    }
    public override void SetPlayer(Player player)
    {
        Player = player;
     _rotation = Player.IPlayerMovement.IsTurned ? 0 : 180;
        transform.rotation = Quaternion.Euler(0,0,_rotation);  
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
      if (other.TryGetComponent<Enemy>(out Enemy enemy))
      {
          Player.IPlayerAttackable.UseAttack();
          enemy.IEnemyHealth.TakeDamage(Player.Damage);
          OnDestroy?.Invoke(0);
      }
  }
  private void Destroy(float waitTime)
  {
      Invoke(nameof(FinuallyDestroy),waitTime);
  }
  private void FinuallyDestroy()
  {
      Instantiate(_electroBall,transform.position,Quaternion.identity);
            for (int i = 0; i < 2; i++)
      {

          CreateBullet(0);
      }
             for (int i = 0; i < 2; i++)
      {

          CreateBullet(-30);
      }
             for (int i = 0; i < 2; i++)
      {

          CreateBullet(30);
      }

            Destroy(gameObject);

  }
  private void CreateBullet(int rotation)
  {
      
                   PlayerAxelBullet playerAxel =  Instantiate(_bullet,transform.position,Quaternion.identity);
          playerAxel.SetPlayer(Player);
          playerAxel.transform.rotation = Quaternion.Euler(0,0,rotation + _rotation);
  }
}
