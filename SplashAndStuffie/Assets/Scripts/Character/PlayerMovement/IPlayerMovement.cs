using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovement 
{
    bool AbleToMove {get;set;}
    bool IsAttacking{get;set;}
    bool IsTurned{get;set;}
    Vector3 Sizes{get;set;}
    void Move(Player player);
    void Flip();
    bool CanMove{get;set;}
     Vector2 TargetVelocity { get; set; }
}
