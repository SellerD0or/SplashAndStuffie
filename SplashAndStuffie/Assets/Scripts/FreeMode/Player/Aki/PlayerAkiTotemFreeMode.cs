using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAkiTotemFreeMode : MonoBehaviour
{
       [SerializeField] private List<PlayerInformationFreeMode> _players;
    private Dictionary<PlayerInformationFreeMode, bool> _currentPlayers = new Dictionary<PlayerInformationFreeMode, bool>();
     [SerializeField] private int _maxHealthForHealing = 94;
     [SerializeField] private int _percentOfAdditionHealth = 6;
     [SerializeField] private float _destroyTime =12;
    private void Start() {
        StartCoroutine(Heal());
        Destroy(gameObject,_destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode player))
        {
           if (!_players.Contains(player))
           {
               _players.Add(player);
                _currentPlayers.Add(player,false);
           }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
          if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode player))
        {
           if (_players.Contains(player))
           {
               _players.Remove(player);
                _currentPlayers.Remove(player);
           }
        }
    }
    private IEnumerator Heal()
    {

        yield return new WaitForSeconds(1);
        foreach (var player in _players)
        {
            if (player.Health <= player.MaxHealth * _maxHealthForHealing / 100)
            {
                 player.Health += player.MaxHealth * _percentOfAdditionHealth /100;
            }
        }
        StartCoroutine(Heal());
    }
}
