using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceFreeMode : MonoBehaviour
{
   [SerializeField] private PlayerInformationFreeMode _player;
      private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<EnemyInformationFreeMode>(out EnemyInformationFreeMode enemy))
        {
            if(_player.PlaceRow.Enemies.Contains(enemy))
            {
            enemy.EnemyAttack.Stop();
            }
        }
    }
}
