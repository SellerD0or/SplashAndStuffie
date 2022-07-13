using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishMovement : MonoBehaviour
{

    [SerializeField] private Transform[] _positions;
    [SerializeField] private Vector3 _vector;
    [SerializeField] private float _speed;
   private void Update() 
   {
       transform.Translate(_vector * _speed * Time.deltaTime);
       if (transform.position.y > _positions[0].position.y)
       {
           transform.position = new Vector2( transform.position.x, _positions[1].position.y);
       }

   }
}
