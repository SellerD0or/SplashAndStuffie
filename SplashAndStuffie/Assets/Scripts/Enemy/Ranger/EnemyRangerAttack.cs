using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangerAttack : MonoBehaviour, IEnemyAttackable
{
        [SerializeField] private float _coolDown = 5;
    public float CoolDown { get => _coolDown ; set => _coolDown = value;}
    public bool IsStayed { get ; set; } = true;

    [SerializeField] private EnemyRangerBullet _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private float _coolDownTime = 2f;
    private bool _isCoolDown;
    [SerializeField] private EnemyRangerAnimator _animator;
        public void Attack(Player _player, Enemy _enemy) 
        {
           Vector3 direction = _player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             _bulletPosition.transform.rotation = Quaternion.Euler(0,0,angle);
            if ((Vector2.Distance(transform.position, _enemy.Player.transform.position) <= _enemy.AttackDistance) &&  IsStayed)//&& _animator.TypeOfAnimation == TypeOfAnimation.Shoot)
            {
                 
               EnemyRangerBullet bullet  =  Instantiate(_bullet, _bulletPosition.position, transform.rotation);
               bullet.transform.rotation = bullet.transform.rotation;
               bullet.SetEnemy(_enemy, _bulletPosition);
               int randomDirection = Random.Range(-3, 3);
               bullet.Player = _player;
               bullet.RigidBody.velocity = transform.TransformDirection(new Vector3(randomDirection,bullet.Speed / 2, 0)); 
               //_bulletPosition.transform.right * bullet.Speed;
               StartCoroutine(Reload());
            }
        }
     /*   private IEnumerator CoolDown()
        {
            _isCoolDown = true;
            yield return new WaitForSeconds(_coolDownTime);
            _isCoolDown = false;

        }*/
         public IEnumerator Reload()
    {
        IsStayed = false;
        yield return new WaitForSeconds(_coolDown);
        IsStayed = true;
    }
}
