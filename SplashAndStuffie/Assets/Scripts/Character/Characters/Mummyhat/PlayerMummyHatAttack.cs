using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMummyHatAttack : MonoBehaviour, IPlayerAttackable
{
  public bool IsStopped { get ; set; }
    private Player _player;
     [SerializeField] private float _waitTime = 4f;
     private Enemy[] _enemies;
     private Enemy _closestEnemy;
    public bool IsAttack { get ; set ; }
    public bool IsCoolDown {get;set;}
      public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public Player Player { get => _player; set => _player = value; }
    public float Angle { get => _angle; set => _angle = value; }
    public Enemy ClosestEnemy { get => _closestEnemy; set => _closestEnemy = value; }

    private float _angle;
      private bool _isJumping;
  public float CoolDownTime { get => _coolDown; set => _coolDown = value; }
    public float Timer { get ; set; }
    public float CurrentTime { get ; set ; }
    public float ResultTime { get ; set ; }
    public bool IsReloading { get; set ; } = true;
    public PlayerInterface PlayerInterface { get ; set; }
    [SerializeField] private int _maxHealthForHealing = 75;
    [SerializeField] private int _percentOfAdditionHealth;
    [SerializeField] private float _coolDown = 1.5f;         
     private bool _ableAttack =false;
     private GetterPlayer _getterPlayer;
     private PlayerMummyHatAnimator _animator;
     private IPlayerMovement _movement;

    public event UnityAction OnAttack;

    private void OnEnable() {
       ContinieToMove();
     }
     private void Start() {
         _getterPlayer =FindObjectOfType<GetterPlayer>();
         PlayerInterface = FindObjectOfType<PlayerInterface>();
         _animator = GetComponent<PlayerMummyHatAnimator>();
     }
       public void UseAttack()
    {
        OnAttack?.Invoke();
    }
    private void Update() {
       if(IsStopped == false)
      {
        Attack();
      }
        if(!IsReloading)
        {
      //  Reload();
        }
    }
    public void Attack()
    {
        
       if(!IsCoolDown)
       { 
       if (Input.GetKeyDown(KeyCode.E) && !_ableAttack)
       {
          if (PlayerInterface.GetterPlayer.Players.Any(e => e.IsDead))
       {
           List<Player> players = new List<Player>();
            foreach (var player in PlayerInterface.GetterPlayer.Players)
       {
           if (player.IsDead)
           {
               players.Add(player);
               
           }
       }
       int _random = Random.Range(0,players.Count);
       players[_random].IsDead = false;
       players[_random].PlayerHealth.IsCoolDown = false;
       
       players[_random].PlayerHealth.Health = players[_random].PlayerHealth.MaxHealth * _percentOfAdditionHealth /100;
                       Debug.LogError(players[_random].IHealthOutPut.HealthOutput + "YES. Mummy hat here");
HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == players[_random].Name);
        healthOutput?.TakeDamage();         
       }
       else
       {
          int numberOfPlayer = PlayerInterface.GetterPlayer.Players.Min(e => e.PlayerHealth.Health);
          Player player = PlayerInterface.GetterPlayer.Players.First(e => e.PlayerHealth.Health == numberOfPlayer);
          Debug.Log(player.name + " " + numberOfPlayer);
          if (numberOfPlayer < player.PlayerHealth.MaxHealth * _percentOfAdditionHealth /100)
          {

              player.PlayerHealth.Health = player.PlayerHealth.MaxHealth * _percentOfAdditionHealth /100;
              //  GetComponent<PlayerMummyHatAnimator>().IsUsingUltimate = true;
             //   Debug.Log(GetComponent<PlayerMummyHatAnimator>().IsUsingUltimate + " MUMMY HAT !");
                Debug.LogError(player.IHealthOutPut.HealthOutput + "YES. Mummy hat here");
HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == player.Name);
        healthOutput?.TakeDamage();         

          }
          
       }
       Debug.LogError(Player +"CORRECT!");
        _movement.AbleToMove = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
               Invoke(nameof(ContinieToMove),5);
        _animator.IsUsingUltimate = true;
        Debug.LogError(        _animator.IsUsingUltimate + " LOL _  WWW");
                      
        //   _enemies = FindObjectsOfType<Enemy>();
      //  FindClosestEnemy();
      //  if (Vector2.Distance(transform.position, ClosestEnemy.transform.position) < 30f)
      // {
           // _player.IPlayerMovement.IsAttacking = true;
                 IsReloading = false;
         IsAttack = true;
         IsCoolDown = true;
                 //  Debug.LogError(IsAttack + " Everything is ok");
          
           StartCoroutine(CoolDown());
         //  StartCoroutine(Reload());
       // }
           
       }
       else if(!Input.GetKeyDown(KeyCode.E))
       {
           IsAttack = false;
         //   _player.IPlayerMovement.IsAttacking = false;
       }
       }
     
    }
    private void ContinieToMove()
    {
      if(_movement == null)
      {
        _movement =GetComponent<PlayerDd1Movement>();
      }
     _movement.AbleToMove = false;
    }
    public void Reload()
    {
        
       //_ableAttack = true;
        // Timer = Timer + Time.deltaTime;
        //  if (Timer > 1)
        //  {
           CurrentTime ++;
              if (CoolDownTime >= CurrentTime)
              {
                  ResultTime = CoolDownTime - CurrentTime;
              }
            if(CurrentTime >= CoolDownTime)
            {
                IsCoolDown = false;
                _ableAttack =false;
                IsReloading = true;
                 PlayerInterface.DisactiveSkill();
                CurrentTime = 0;
            }
               else
        {
            PlayerInterface.ActiveSkill();
              _ableAttack = true;
        }
         //  Timer = 0;
           
        //  }
         
       // StartCoroutine(Reload());
    }
    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(3f);
       IsJumping = true;
         Vector3 direction = ClosestEnemy.transform.position - transform.position;
            Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
       // Invoke(nameof(Land), 2f);
       
    }
    private void Land() => _isJumping = false;
    


    public void SetPlayer(Player player)
    {
        Player = player;
    }
     public IEnumerator CoolDown()
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(_waitTime);
        IsCoolDown = false;
    }
      public void StartReload()
    {
        Invoke(nameof(Reload),_player.IPlayerAnimator.TimeForShoot);
    }
}
