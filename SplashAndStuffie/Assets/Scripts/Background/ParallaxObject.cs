using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
  private float _startingPosition;
  private float _size;
   private Camera _camera;
   [SerializeField] private float _speed;
   private void Start() {
       _camera= Camera.main;
       _startingPosition = transform.position.x;
       _size = GetComponent<SpriteRenderer>().bounds.size.x;

   }
   private void Update() {
      float temp = _camera.transform.position.x * (1 - _speed);
     float distance = _camera.transform.position.x * _speed;
    transform.position = new Vector3(_startingPosition + distance, transform.position.y, transform.position.z);
      if (temp > _startingPosition + _size)
      {
          _startingPosition += _size;
    }
      else if(temp < _startingPosition - _size)
      {
          _startingPosition -= _size;
      }
   }
}
