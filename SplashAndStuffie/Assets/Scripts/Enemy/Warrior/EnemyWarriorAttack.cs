using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorAttack : MonoBehaviour, IEnemyAttackable
{
    [SerializeField] private Warrior _enemy;
    [SerializeField] private float _coolDown = 3;
    public float CoolDown { get => _coolDown ; set => _coolDown = value;}
    private bool _isStayed = true;
    public bool IsStayed { get => _isStayed ; set => _isStayed = value; } 
    private Enemy _lastEnemy;
    private bool _isAbleToAttackEnemy;
    public void Attack(Player _player, Enemy _enemy) 
        {
            Debug.LogError(IsStayed + "" +(Vector2.Distance(transform.position, _enemy.Target.transform.position) <= _enemy.AttackDistance));
            if (Vector2.Distance(transform.position, _enemy.Target.transform.position) <= _enemy.AttackDistance && IsStayed)
            {
                  Debug.LogError("ATTACK BY WARRIOR" + _player );
                  if(_enemy.IsBewitched==false)
                  {
                  _player.PlayerHealth.TakeDamage(_enemy.Damage);
                  }
                  else if(_enemy.IsBewitched)
                  {
                     // _lastEnemy?.IEnemyHealth.TakeDamage(_enemy.Damage);
                  }
                  StartCoroutine(Reload());
                //_enemy.Accept(_enemy.Visitor);
            }
        }
        private void OnTriggerStay2D(Collider2D other) {
            if (other.TryGetComponent<Enemy>(out Enemy enemy) && _isAbleToAttackEnemy ==false && _enemy.IsBewitched)
            {
                   Debug.Log("ATTAK ANOTHER ENEMY!!!!");
                enemy.IEnemyHealth.TakeDamage(_enemy.Damage);
                StartCoroutine(CoolDownAttack());
            }
        }
        private IEnumerator CoolDownAttack()
        {
            _isAbleToAttackEnemy = true;
            yield return new WaitForSeconds(CoolDown);
            _isAbleToAttackEnemy = false;
        }
    public IEnumerator Reload()
    {
        IsStayed = false;
        yield return new WaitForSeconds(CoolDown);
        Debug.LogError("STAYED!!!");
        IsStayed = true;
    }
}
