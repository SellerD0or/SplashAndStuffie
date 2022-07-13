using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFreeMode : MonoBehaviour
{
  [SerializeField] private EnemyAttackFreeMode _enemyAttack;
     private Enemy _enemy;
       [SerializeField] private EnemyInformationFreeMode enemyInformationFreeMode;
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
            public EnemyInformationFreeMode EnemyInformationFreeMode { get => enemyInformationFreeMode; set => enemyInformationFreeMode = value; }
    public EnemyAttackFreeMode EnemyAttack { get => _enemyAttack; set => _enemyAttack = value; }

    private void Start() {
     
   // _enemy = GetComponent<Enemy>();
  //  _enemy.enabled = false;   
  }
  private void Update() {
    if(EnemyInformationFreeMode.CanMove)
    enemyInformationFreeMode.RigidBody2D.velocity = EnemyInformationFreeMode.Direction * EnemyInformationFreeMode.Speed;
  }
}
