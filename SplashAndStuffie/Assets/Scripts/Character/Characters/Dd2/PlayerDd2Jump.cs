using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDd2Jump : MonoBehaviour
{
     public event UnityAction OnJump;
    [SerializeField] private PlayerDd2Attack _playerDd2Attack;
    private bool _stop= true;
    private void Stop()
    {
        _stop = false;
        Invoke(nameof(Reload),2);
    }
    private void Reload() => _stop = true;
private void Update() {
    if (_playerDd2Attack.IsJumping) 
    {
        if (Vector3.Distance(transform.position, _playerDd2Attack.ClosestEnemy.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,_playerDd2Attack.ClosestEnemy.transform.position, _playerDd2Attack.Player.Speed * 2 * Time.deltaTime);
        }
        else
        {
            OnJump?.Invoke();
            _playerDd2Attack.IsJumping = false;
            Invoke(nameof(Kill), 1);
            _playerDd2Attack.Player.IPlayerMovement.IsAttacking = false;
           _playerDd2Attack.Player.IPlayerMovement.AbleToMove = false;

            return;
        }
        //if(Mathf.Abs(transform.position.x - _playerDd2Attack.ClosestEnemy.transform.position.x) < 1f)
        //{
        //    Debug.LogError("Sstsa");
       //   Stop();
       // }
     //  _playerDd2Attack.Player.Rigidbody2D.velocity = transform.TransformDirection(new Vector3(-_playerDd2Attack.Angle,_playerDd2Attack.Player.Speed /2,0));
    }
}
private void Kill()
{
      _playerDd2Attack.UseAttack();

    _playerDd2Attack.ClosestEnemy.IEnemyHealth.TakeDamage(_playerDd2Attack.Player.Damage);
}

}
