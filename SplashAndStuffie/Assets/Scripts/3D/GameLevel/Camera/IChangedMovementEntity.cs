using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangedMovementEntity 
{
    Vector3 StartLocalScale{get;set;}
    void TurnTop();
    void LookAt();
    void TurnRight();
    void TurnLeft();
    void SetNormal();
}
