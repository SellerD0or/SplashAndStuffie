using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd2Movement : MonoBehaviour,IPlayerMovement
{
  [SerializeField] private bool _isTurned = false;
    public bool IsAttacking{get;set;}
      public bool IsTurned {get => _isTurned ;set => _isTurned =value;}
    public Vector3 Sizes {get;set;}
    public bool CanMove { get; set ; }
    public Vector2 TargetVelocity { get; set; }
    public bool AbleToMove { get ; set; }

    private void Start() {
        Sizes = transform.localScale;
    }
    public void Flip()
    {
    float _turn = IsTurned ?Sizes.x : -Sizes.x;
      Vector3 scale = transform.localScale;
        scale.x = _turn;
       transform.localScale = scale;
    }

    public void Move(Player player)
    {
      Debug.LogError("MOVE DD2 " + player + IsAttacking + " / " + AbleToMove);
        if(!IsAttacking && !AbleToMove)
        {
          Debug.Log("EVERYTHIBG IS OKEY IN DD2 MOVING!!!");
        float movement = Input.GetAxis("Horizontal");
         TargetVelocity = new Vector2(movement, Input.GetAxis("Vertical"));
       player.Rigidbody2D.velocity = TargetVelocity * player.Speed; 
       CanMove =  (TargetVelocity.x != 0 && TargetVelocity.y != 0) ? true : false;
        if(movement != 0)
       {
           IsTurned = movement > 0;
           Flip();
       }
        }
        else
        {
            player.Rigidbody2D.velocity = Vector2.zero;
        }
    }
}
