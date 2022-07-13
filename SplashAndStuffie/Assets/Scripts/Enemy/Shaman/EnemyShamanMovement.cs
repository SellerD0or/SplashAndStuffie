using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShamanMovement : MonoBehaviour, IEnemyMovement
{
    public bool CanNormalMove { get; set; }
     [SerializeField] private float _minXForMovement = -100;
    public float MinXForMovement { get => _minXForMovement; set => _minXForMovement = value ; }

    public void Move(Enemy _enemy)
    {
      //  throw new System.NotImplementedException();
    }

    
}
