using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShamanBullet : EnemyBullet
{
    public override Enemy Enemy { get; set; }
    [SerializeField] private Animator _animator;
    [SerializeField] private float _waitTime = 5f;
    [SerializeField] private Collider2D _collider;
    private float _coolDownTime;
    private Vector3 _startPosition;
    [SerializeField] private float _speed;
    private float _increasingSpeed;
    private void Start() {
        _startPosition = transform.position;
        transform.position = new Vector3(transform.position.x,transform.position.y + 60, 0);
        _coolDownTime = _waitTime /2;
        StartCoroutine(Disappear());
    }
    private void Update() {
        if (Vector3.Distance(_startPosition, transform.position) > 1)
        {
            _increasingSpeed = _speed + Time.deltaTime;
            transform.Translate(Vector2.down * _increasingSpeed);
        }
    }
    private IEnumerator Disappear()
    {
        
        yield return new WaitForSeconds(_coolDownTime);
        _collider.enabled = true;
        _animator.SetTrigger("Disappear");// with color: " + _renderer.color);
        yield return new WaitForSeconds(_coolDownTime);
        Destroy(gameObject);
    }
    public override void SetEnemy(Enemy enemy, Transform _spawnPosition)
    {
        Enemy = enemy;
      
    }
  private void OnTriggerEnter2D(Collider2D other) 
  {
      if (Enemy.IsBewitched == false)
      {
          if(other.TryGetComponent<Player>(out Player player))
          {
          player.PlayerHealth.TakeDamage(Enemy.Damage);
          }
      }
      else if(Enemy.IsBewitched)
      {
         if(other.TryGetComponent<Enemy>(out Enemy enemy))
          {
          enemy.IEnemyHealth.TakeDamage(Enemy.Damage);
          }
      }
  }

}

