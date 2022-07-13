using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFreeMode : MonoBehaviour
{
  [SerializeField] private PlayerHealthFreeMode _playerHealth;
  [SerializeField] private PlayerInformationFreeMode _playerInformationFreeMode;
  [SerializeField]  private Player _player;
        private float _startSpeed;

    public Player Player { get => _player; set => _player = value; }
    public Vector2 Direction { get; set; }
    public float StartSpeed { get => _startSpeed; set => _startSpeed = value; }
    [SerializeField] private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    public PlayerInformationFreeMode PlayerInformationFreeMode { get => _playerInformationFreeMode; set => _playerInformationFreeMode = value; }
    public PlayerHealthFreeMode PlayerHealth { get => _playerHealth; set => _playerHealth = value; }

    private void Awake() {
    _player = GetComponent<Player>();
  //  StartSpeed = Speed;
    //Speed = _player.Speed;
    
    //_player.enabled = false;   
  }
  private void Update() {
    if(PlayerInformationFreeMode.CanMove)
    {
    _player.Rigidbody2D.velocity = _playerInformationFreeMode.Direction * _playerInformationFreeMode.Speed;
    }
  }
}
