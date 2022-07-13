using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd1ShotPosition : MonoBehaviour
{
    [SerializeField] private int _direction;
    public int Direction { get => _direction; set => _direction = value; }
}
