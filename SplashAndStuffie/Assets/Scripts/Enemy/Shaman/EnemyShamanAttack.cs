using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShamanAttack : MonoBehaviour, IEnemyAttackable
{
       [SerializeField] private float _coolDown = 5;
    public float CoolDown { get => _coolDown ; set => _coolDown = value;}
    public bool IsStayed  { get ; set; } = true;
        [SerializeField] private EnemyShamanBullet _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private float _coolDownTime = 2f;
    private bool _isCoolDown;
    [SerializeField] private EnemyShamanShadow _shadow;
        public void Attack(Player _player, Enemy _enemy) 
        {
           
            if ((Vector2.Distance(transform.position, _enemy.Target.transform.position) <= _enemy.AttackDistance) &&  _isCoolDown == false && IsStayed)
            {
                Debug.Log("YOUY CAN SHOOT, SHAMAN!!!");
               _bulletPosition = _enemy.Target.transform;
               StartCoroutine(CoolDownBullet(_enemy));
               StartCoroutine(Reload());
            }
        }
        private IEnumerator CoolDownBullet(Enemy enemy)
        {
            _isCoolDown = true;
            yield return new WaitForSeconds(_coolDownTime);
            Instantiate(_shadow,new Vector2(_bulletPosition.position.x, _bulletPosition.position.y - 0.8f),transform.rotation);
            EnemyBullet bullet  =  Instantiate(_bullet, _bulletPosition.position, transform.rotation);
               bullet.SetEnemy(enemy, _bulletPosition);
               
            _isCoolDown = false;

        }
         public IEnumerator Reload()
    {
        IsStayed = false;
        yield return new WaitForSeconds(_coolDown);
        IsStayed = true;
    }
}
