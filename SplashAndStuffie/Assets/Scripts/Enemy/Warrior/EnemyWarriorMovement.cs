using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorMovement : MonoBehaviour, IEnemyMovement
{
    public static bool CanMove;
    private Vector3 _startSize;

    public bool CanNormalMove { get ; set; }
    [SerializeField] private float _minXForMovement = -100;
    public float MinXForMovement { get => _minXForMovement; set => _minXForMovement = value ; }

    private void Start() {
    _startSize = transform.localScale;
}
private void OnEnable() {
    CanMove = false;
    Debug.LogError(CanMove + " ABLE TO MOVE!!!");
}
   public void Move(Enemy enemy)
   {
       if(!CanNormalMove)
       {
           Debug.LogError("PLAYER CAN ATTACK!!");
           
       transform.position = Vector3.MoveTowards(transform.position, new Vector2(Mathf.Clamp(enemy.Target.transform.position.x,MinXForMovement, Mathf.Infinity), enemy.Target.transform.position.y), enemy.Speed);

       
       if (transform.position.x > enemy.Target.transform.position.x)
       {
           transform.localScale = new Vector2(-_startSize.x, transform.localScale.y);
       }
       else
       {
             transform.localScale = new Vector2(_startSize.x, transform.localScale.y);
       }
       }
   }
}
