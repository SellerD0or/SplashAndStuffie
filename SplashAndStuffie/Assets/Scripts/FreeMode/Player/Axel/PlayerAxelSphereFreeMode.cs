using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAxelSphereFreeMode : MonoBehaviour
{
      [SerializeField] private GameObject _electroBall;
        [SerializeField] private PlayerAxelButlletFreeMode _bullet;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _speed;
    public PlayerInformationFreeMode Player { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool AbleToMove { get => _ableToMove; set => _ableToMove = value; }

    private event UnityAction<float> OnDestroy; 
    private EnemyInformationFreeMode[] _enemies;
    private EnemyInformationFreeMode _closestEnemy;
    private bool _isCoolDown;
    private bool _canMove;
    private Vector3 _startPosition = new Vector3();
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _randomDirection;
    private bool _ableToMove = true;
    private float _rotation;
    private void Start() {
        OnDestroy += Destroy;
        StartCoroutine(CoolDown(1));
        OnDestroy?.Invoke(_waitTime);
        
      // _rigidbody.velocity = transform.TransformDirection(new Vector3(_randomDirection,0, 0));
        
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
        if(Player.ClosestEnemy != null)
        {
                transform.position = Vector3.MoveTowards(transform.position, Player.ClosestEnemy.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            if(Player.PlaceRow.IsLowPlace== false)
            {
            if(Player.PlaceRow.IsRight)
            {
            transform.Translate(Vector2.right *_speed * Time.deltaTime);
            }
            else
            {
                 transform.Translate(Vector2.left *_speed * Time.deltaTime);     
            }
            }
            else
            {
                  transform.Translate(Vector2.down *_speed * Time.deltaTime);     
            }
        }
       // transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
   public IEnumerator CoolDown(float waitTime)
    {
       // _enemies = FindObjectsOfType<EnemyInformationFreeMode>();
        FindClosestEnemy();
        yield return new WaitForSeconds(waitTime);
    }
     public  EnemyInformationFreeMode FindClosestEnemy() {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (EnemyInformationFreeMode enemy in Player.PlaceRow.Enemies) {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                _closestEnemy = enemy;
                distance = curDistance;
            }
        }
        return _closestEnemy;
     }

    public void SetPlayer(PlayerInformationFreeMode player)
    {
        Player = player;
    }
      private void OnTriggerEnter2D(Collider2D other) 
      {
      if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
      {
          //  if(Player.PlaceRow.Enemies.Contains(enemy))
         // {
          Debug.LogError(enemy);
          OnDestroy?.Invoke(0);
         // }
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
      
                   PlayerAxelButlletFreeMode playerAxel =  Instantiate(_bullet,transform.position,Quaternion.identity);
          playerAxel.SetPlayer(Player);
          playerAxel.transform.rotation = Quaternion.Euler(0,0,rotation);
  }
}
