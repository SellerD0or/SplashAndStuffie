using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour
{
  
    [SerializeField] private Transform[] _positions;
    [SerializeField] private Vector3 _vector;
    [SerializeField] private float _speed;
   private void Update() 
   {
       transform.Translate(_vector * _speed * Time.deltaTime);
       if (transform.position.x > _positions[0].position.x)
       {
           transform.position = new Vector2(_positions[1].position.x, transform.position.y);
       }

   }
}
