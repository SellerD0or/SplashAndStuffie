using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCamera : MonoBehaviour
{
    [SerializeField] private Transform _startPosition, _endPosition;
    private bool _isPointReached = false;
    private bool _isMovedToEnd;
    [SerializeField] private float _speed = 4;
    private float _range = 0.1f;
    public void MoveToEndPosition()
    {
        _isMovedToEnd = false;
        _isPointReached = true;
    }
    public void MoveToStartPosition()
    {
        _isMovedToEnd = true;
        _isPointReached = true;
    }
    private void Update() 
    {
        if (_isPointReached)
        {
          if (_isMovedToEnd == false)
          {
              transform.position = Vector3.MoveTowards(transform.position, new Vector3(_endPosition.position.x,transform.position.y,-10), _speed *Time.deltaTime);
              if (Vector2.Distance(new Vector2(_endPosition.position.x,transform.position.y), transform.position) < _range)
             {
                 _isPointReached = false;
             }
          }
          else
          {
             transform.position = Vector3.MoveTowards(transform.position, new Vector3(_startPosition.position.x,transform.position.y,-10), _speed *Time.deltaTime); 
             if (Vector2.Distance(new Vector2(_startPosition.position.x,transform.position.y), transform.position) < _range)
             {
                 _isPointReached = false;
             }
          }
        }
    }
}
