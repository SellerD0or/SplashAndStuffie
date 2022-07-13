
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEntity : MonoBehaviour
{
  [SerializeField] private Camera _camera;
  private float _startPosition, _length;
  [SerializeField] private float _speed;
  [SerializeField] private Transform[] _positions;
  [SerializeField] private Player _player;
  private void Start() {
      _startPosition = transform.position.x;
      _length = GetComponent<SpriteRenderer>().bounds.size.x;
      _player = FindObjectOfType<Player>();
  }
  private void Update() {
      if(_positions[0].transform.position.x < _camera.transform.position.x && _positions[1].transform.position.x > _camera.transform.position.x )
      {
        // transform.position = Vector3.Lerp(transform.position, new Vector3(_camera.transform.position.x, transform.position.y,transform.position.z), _speed * Time.fixedDeltaTime);
     float temp = _camera.transform.position.x * (1 - _speed);
     float distance = _camera.transform.position.x * _speed;
    transform.position = new Vector3(_startPosition + distance, transform.position.y, -transform.position.z);
     if (temp > _startPosition + _length)
      {
          _startPosition += _length;
    }
      else if(temp < _startPosition - _length)
      {
          _startPosition -= _length;
      }
      }
  }
}
