using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTattiRoarFreeMode : MonoBehaviour
{
      [SerializeField] private PlayerInformationFreeMode _player;
    [SerializeField] private PolygonCollider2D _collider;
    private bool _isEndedCooldown;
    private IEnumerator CoolDown()
    {
        _isEndedCooldown = true;
        yield return new WaitForSeconds(0.3f);
        _isEndedCooldown =false;
    }
    public void Open()
    {
        Invoke(nameof(AppearRoad),1.5f);
    }
    public void Close()
    {
        _collider.enabled = false;
    }
    private void AppearRoad()
    {
        _collider.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy) && !_isEndedCooldown && _collider.enabled)
        {
            Debug.Log("AttACL");
            enemy.EnemyAttack.EnemyHealth.TakeDamage(_player.Damage);
            StartCoroutine(CoolDown());
        }
    }
}
