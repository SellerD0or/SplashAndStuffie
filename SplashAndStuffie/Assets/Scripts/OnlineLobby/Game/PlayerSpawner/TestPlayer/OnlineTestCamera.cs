using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineTestCamera : MonoBehaviour
{
   [SerializeField] private Transform _player;
   private Vector3 _playerVector;
   [SerializeField]private int _speed;
   private void Update() {
       _playerVector = _player.position;
       _playerVector.z = -10;
       transform.position = Vector3.Lerp(transform.position,_playerVector,_speed * Time.deltaTime);
   }
}
