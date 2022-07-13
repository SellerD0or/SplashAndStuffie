using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class PlayerAxelRocket : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private float _speed = 20;
  public float PositionYForStop { get; set; }
    public Vector2 Vector { get => _vector; set => _vector = value; }
    public float Speed { get => _speed; set => _speed = value; }

    [SerializeField] private int _damage = 420;
  [SerializeField] private float _destroyTime = 6;
 [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
 private UnityArmatureComponent _rocket;
 private Vector2 _vector = new Vector2(0, -1);
 [SerializeField] private ParticleSystem _paarticle;
 [SerializeField] private float _range = 4;
  private void Start() {
      _rocket = GetComponent<UnityArmatureComponent>();
    //  transform.rotation = Quaternion.Euler(0,0,180);
     // Invoke(nameof( Destroy),(PositionYForStop / _speed));
  }
  public void SetDistance(float _distance)
  {
      PositionYForStop = _distance;
      float destoryTime = PositionYForStop / Speed;
      Invoke(nameof(Destroy),1.5f);

     
  }
  private void Update() {
      if (transform.position.y > (PositionYForStop + 1.5f))
      {
          transform.Translate(_vector * Speed * Time.deltaTime);
      }
  }
  public void Destroy()
  {
      _rocket.animation.FadeIn("boom",0);
      Instantiate(_particle,transform.position,Quaternion.identity);
      List<Enemy> choosenEnemies= new List<Enemy>();
      Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _range);
      foreach (var item in collider2D)
      {
          if (item.TryGetComponent<Enemy>(out Enemy enemy))
          {
              choosenEnemies.Add(enemy);
          }
      }
      List<Enemy> enemies = new List<Enemy>();
      foreach (var item in choosenEnemies)
      {
          enemies.Add(item);
      }
      foreach (var item in enemies)
      {
          Debug.LogError("enemy take damage " + item);
          item.IEnemyHealth.CanAttack = false;
          item.IEnemyHealth.TakeDamage(_damage);
          item.IEnemyHealth.StartApplyingExraDamage(320);
      }
      _paarticle.Stop();
      Destroy(gameObject,1f);
  }
  private void OnTriggerStay2D(Collider2D other) 
  {
     if (other.TryGetComponent<Enemy>(out Enemy enemy))
     {
         if(_enemies.Contains(enemy) == false)
         {
         _enemies.Add(enemy);
         }
     } 
  }
}
