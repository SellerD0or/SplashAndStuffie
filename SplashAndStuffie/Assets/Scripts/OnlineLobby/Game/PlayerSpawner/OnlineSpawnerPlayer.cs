using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineSpawnerPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _minimumX, _minimumY, _maximumX,_maximumY;
    private void Start() {
        Vector2 randomPosition = new Vector2(Random.Range(_minimumX, _maximumX), Random.Range(_minimumY, _maximumY));
        PhotonNetwork.Instantiate(_player.name,randomPosition,Quaternion.identity);
    }
}
