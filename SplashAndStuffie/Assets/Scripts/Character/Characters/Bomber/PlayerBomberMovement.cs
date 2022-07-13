using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomberMovement : MonoBehaviour, IPlayerMovement
{
  [SerializeField] private bool _isTurned;
       public bool IsTurned {get => _isTurned;set => _isTurned = value;}
    public Vector3 Sizes {get;set;}
    public bool CanMove { get; set ; }
    public Vector2 TargetVelocity { get; set; }
    public bool IsAttacking { get ; set ; }
    public bool AbleToMove { get ; set ; }

    private Vector3 _jumpPosition;
     private bool _canMove = true;
     [SerializeField] private float _coolDown = 3;
     private bool _isJump  =false;
     private Player _player;
   private PlayerBomberAnimator _playerBomber;
  private bool _mustStay;
    private void Start() {
       GetComponent<PlayerDd1Attack>().OnPressE += CannotMove;
        _playerBomber  = GetComponent<PlayerBomberAnimator>();
        Sizes = transform.localScale;
    }
    private void CannotMove()
    {
      _mustStay= true;
      Invoke(nameof(ContinieToMove),3);
    }
    private void ContinieToMove() => _mustStay = false;
    private void OnEnable() {
      _isJump = false;
     _jumpPosition =  transform.position;
    }
    public void Flip()
    {
      if(_mustStay == false)
      {
    float _turn = IsTurned ?Sizes.x : -Sizes.x;
      Vector3 scale = transform.localScale;
        scale.x = _turn;
        
        _jumpPosition.x = IsTurned ? transform.position.x + 8 : transform.position.x - 8;
       
         if (TargetVelocity.y != 0)
         {
            Debug.Log(TargetVelocity.y + " Sasa");
            // _position.y = TargetVelocity.y < 0 ? transform.position.y + 3 : transform.position.y - 3;
         }
       transform.localScale = scale;
      }
    }

    public void Move(Player player)
    {
      if (!AbleToMove && player.IsAttack() == false && _mustStay == false)
      {
        float movement = Input.GetAxis("Horizontal");
         TargetVelocity = new Vector2(movement, Input.GetAxis("Vertical"));
         
       //player.Rigidbody2D.velocity = TargetVelocity * player.Speed; 
       CanMove =  (TargetVelocity.x != 0 && TargetVelocity.y != 0) ? true : false;
        if((movement != 0 || TargetVelocity.y != 0 )&& _canMove && _playerBomber.CanMove)
       {
         _canMove = false;
           _player = player;
         if (movement != 0)
         {
             IsTurned = movement > 0;
           Flip();
           
         }
         if (TargetVelocity.y != 0)
         {
            // _jumpPosition.y = TargetVelocity.y < 0 ? transform.position.y - 3 : transform.position.y + 3;
             if (TargetVelocity.y < 0 && transform.position.y - 3 > -9.38f)
             {
               _jumpPosition.y  = transform.position.y- 3;
             }
             else if(transform.position.y + 3 < 15.47f && TargetVelocity.y >0)
             {
                   _jumpPosition.y  = transform.position.y+ 3;
             }

         }
           
           Invoke(nameof(StartJump), 1.5f);
          // Jump(player);
           
           Invoke(nameof(CoolDown), _coolDown);
       }
       if (_isJump)
       {
           Jump(_player);
       }
      }
    }
    private void StartJump() => _isJump = true;
    private void CoolDown() => _canMove = true;
    private void Jump(Player player)
    {   
      Debug.Log(_jumpPosition + " TO MOVE");
       transform.position =  Vector3.MoveTowards(transform.position,_jumpPosition, _player.Speed * Time.deltaTime);
         
         if (Vector2.Distance(transform.position, _jumpPosition) < 0.1)
         {
             _isJump =false;
         }
    }
    public void SetPosition(Vector3 position) 
    {
      _jumpPosition = position;
      transform.position =  _jumpPosition;
    }
    
}
