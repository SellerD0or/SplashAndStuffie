using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerMovement3DDirection
{
    Right,
    Left,
    Up,
    Down
}
public class PlayerMovement3D : MonoBehaviour
{
    private bool _isMove = true;
    private Player _player;
    private void Start() {
        _player = GetComponent<Player>();
        _player.IPlayerMovement.AbleToMove = true;
    }
    private void Update() {
        if (_isMove)
        {
            transform.Translate(Vector3.right *_player.Speed * Time.deltaTime );
        }
    }
}
