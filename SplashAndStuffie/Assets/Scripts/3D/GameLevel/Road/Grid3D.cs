using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D : MonoBehaviour
{
    [SerializeField] private PlayerMovement3DDirection _direction;
    private Vector3 _position;

    public PlayerMovement3DDirection Direction { get => _direction; set => _direction = value; }

    public void OnClick()
    {

    }
}
