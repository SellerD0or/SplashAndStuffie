using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTattiRoar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PolygonCollider2D _collider;
    private bool _isEndedCooldown;

    public PolygonCollider2D Collider { get => _collider; set => _collider = value; }
    public bool IsEndedCooldown { get => _isEndedCooldown; set => _isEndedCooldown = value; }

    private IEnumerator CoolDown()
    {
        IsEndedCooldown = true;
        yield return new WaitForSeconds(0.3f);
        IsEndedCooldown =false;
    }
    public void Open()
    {
        IsEndedCooldown = false;
        Invoke(nameof(AppearRoad),1.5f);
    }
    public void Close()
    {
        Collider.enabled = false;
    }
    private void AppearRoad()
    {
        Collider.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) && !IsEndedCooldown)
        {

                    Debug.LogError("Damage: - " + enemy);
                    _player.IPlayerAttackable.UseAttack();
            enemy.IEnemyHealth.TakeDamage(_player.Damage);
             _player.Ability.ReloadAmount(0.25f);
            StartCoroutine(CoolDown());
        }
    }
}
