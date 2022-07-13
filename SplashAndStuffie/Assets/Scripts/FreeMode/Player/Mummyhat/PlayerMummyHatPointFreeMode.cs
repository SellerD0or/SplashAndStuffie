using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMummyHatPointFreeMode : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;

    public CircleCollider2D Collider { get => _collider; set => _collider = value; }
    public PlayerInformationFreeMode PlayerInformation { get; set; }
    [SerializeField] private float _coolDown = 0.6f;
    [SerializeField] private float _additionHealth = 105;
    private bool _isCoolDownPlayer;
    private bool _isCoolDownEnemy;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemyInformationFreeMode) && !_isCoolDownEnemy)
        {
         enemyInformationFreeMode. EnemyAttack.EnemyHealth.TakeDamage(PlayerInformation.Damage);
         StartCoroutine(CoolDownEnemy());
        }
         if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode playerInformationFreeMode) && !_isCoolDownPlayer)
        {
            if(playerInformationFreeMode.Health < playerInformationFreeMode.MaxHealth * 80 / 100)
            {
         playerInformationFreeMode.Health = playerInformationFreeMode.Health * _additionHealth / 100;
         StartCoroutine(CoolDownPlayer());
            }
        }
    }
    private IEnumerator CoolDownPlayer()
    {
        _isCoolDownPlayer = true;
        yield return new WaitForSeconds(_coolDown);
        _isCoolDownPlayer = false;
    }
     private IEnumerator CoolDownEnemy()
    {
        _isCoolDownEnemy = true;
        yield return new WaitForSeconds(_coolDown);
        _isCoolDownEnemy = false;
    }
}
