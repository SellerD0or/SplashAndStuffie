using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerAxelRocketFreeMode : MonoBehaviour
{
    private PlayerInformationFreeMode _playerInformation;
        [SerializeField] private GameObject _particle;
    [SerializeField] private float _speed = 20;
  public float PositionYForStop { get; set; }
    public PlayerInformationFreeMode PlayerInformation { get => _playerInformation; set => _playerInformation = value; }

    [SerializeField] private int _damage = 420;
  [SerializeField] private float _destroyTime = 6;
  private List<EnemyInformationFreeMode> _enemies = new List<EnemyInformationFreeMode>();
  private bool _isReached;
   private UnityArmatureComponent _rocket;
 [SerializeField] private ParticleSystem _paarticle;

  private void Start() {
    _rocket = GetComponent<UnityArmatureComponent>();
      Invoke(nameof( Destroy),_destroyTime);
  }
  private void Update() {
      if (transform.position.y > PositionYForStop)
      {
          transform.Translate(Vector2.down * _speed * Time.deltaTime);
      }
  }
  /*private void Update() {
      if(_isReached == false)
      {
      if (transform.position.y > PositionYForStop)
      {
          transform.Translate(Vector2.down * _speed * Time.deltaTime);
      }
      else
      {
          _isReached = true;
          Debug.Log("Destory Axel rocket");
          Destroy();

      }
      }
  }*/
  public void Destroy()
  {
    _rocket.animation.FadeIn("boom",0);
      Instantiate(_particle,transform.position,Quaternion.identity);
      List<EnemyInformationFreeMode> enemies = new List<EnemyInformationFreeMode>();
      foreach (var item in _enemies)
      {
          enemies.Add(item);
      }
      foreach (var item in enemies)
      {
          item.EnemyAttack.EnemyHealth.TakeDamage(_damage);
      }
         _paarticle.Stop();
         Destroy(gameObject,1f);
  }
  private void OnTriggerEnter2D(Collider2D other) 
  {
     if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
     {
         if(PlayerInformation.PlaceRow.Enemies.Contains(enemy))
         _enemies.Add(enemy);
     } 
  }
  private void OnTriggerExit2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
     {
         _enemies.Remove(enemy);
     } 
  }
}
