using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackFreeMode : MonoBehaviour
{
  [SerializeField] private EnemyHealthFreeMode _enemyHealth;
  public EnemyHealthFreeMode EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
  [SerializeField] private float _waitTime = 2f;
    [SerializeField] private EnemyInformationFreeMode _enemyInformationFreeMode;
      public bool CanAttack { get; set; }
      public bool IsEndedCoolDown {get;set;}
      
    public EnemyInformationFreeMode EnemyInformationFreeMode { get => _enemyInformationFreeMode; set => _enemyInformationFreeMode = value; }
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public abstract void Stop();
    public abstract void AttackGenerator(GeneratorFreeMode generator);
    public abstract void ContinieToMove();
    public abstract IEnumerator CoolDown();
}
