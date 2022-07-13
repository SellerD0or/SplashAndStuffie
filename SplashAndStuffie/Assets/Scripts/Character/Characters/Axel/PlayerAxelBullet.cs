using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAxelBullet : PlayerBullet, IMoveableBullet
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
    private void Start() {
        OnDestroy += Destroy;
        StartCoroutine(CoolDown(1));
        OnDestroy?.Invoke(_waitTime);
        
        //_rigidbody.velocity = transform.TransformDirection(new Vector3(_randomDirection,Speed / 2, 0));
        
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
    
    private void Update()
     {  
     transform.Translate(Vector2.right * _speed);   
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
         Player.Ultimate.ReloadAmount(1);

          enemy.IEnemyHealth.TakeDamage(Player.Damage);
          OnDestroy?.Invoke(0);
      }
  }
  private void Destroy(float waitTime)
  {
      Destroy(gameObject, waitTime);
  }
}
