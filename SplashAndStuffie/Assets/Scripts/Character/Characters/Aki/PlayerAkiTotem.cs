using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAkiTotem : MonoBehaviour
{
      [SerializeField] private Image _healthBar;
     private float _fillValue;
    [SerializeField] private List<Player> _players;
    private Dictionary<Player, bool> _currentPlayers = new Dictionary<Player, bool>();
     [SerializeField] private int _heal = 720;
     [SerializeField] private float _damage = 150;
     [SerializeField] private float _destroyTime =12;
     private GetterPlayer _getterPlayer;
     [SerializeField] private float _health = 5600;
    public GetterPlayer GetterPlayer { get => _getterPlayer; set => _getterPlayer = value; }
    public float Health { get => _health; set => _health = value; }
    public float MaxHealth { get; set; }
    private void Start() {
        MaxHealth = Health;
        StartCoroutine(Heal());
        _getterPlayer = FindObjectOfType<GetterPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Player>(out Player player))
        {
           if (!_players.Contains(player))
           {
               _players.Add(player);
                _currentPlayers.Add(player,false);
           }
        }
        if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bullet))
        {
            TakeDamage(bullet.Enemy.Damage);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
          if (other.TryGetComponent<Player>(out Player player))
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
            if (player.PlayerHealth.Health <= player.PlayerHealth.MaxHealth - _heal)
            {
                 player.PlayerHealth.Health = player.PlayerHealth.Health + _heal;
                 if (player.PlayerHealth.Health > player.PlayerHealth.MaxHealth)
                 {
                     player.PlayerHealth.Health =player.PlayerHealth.MaxHealth;
                 }
       HealthOutput healthOutput =  GetterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == player.Name);
        healthOutput?.TakeDamage();
            }
        }
        if (Health > 0)
        {
             TakeDamage(_damage);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(Heal());
    }
    private void TakeDamage(float damage)
    {
        Health -= damage;
         _fillValue = (float)Health;
        _fillValue = _fillValue / MaxHealth;
        _healthBar.fillAmount = _fillValue;
    }

}
