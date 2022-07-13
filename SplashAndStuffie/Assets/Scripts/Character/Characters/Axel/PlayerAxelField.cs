using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelField : MonoBehaviour
{
   [SerializeField] private Transform _minPosition;
   [SerializeField] private Transform _maxPosition;
   public Vector2 ReturnPosition()
   {
       float xPosition =Random.Range(_minPosition.position.x, _maxPosition.position.x);
      float yPosition =Random.Range(_minPosition.position.y, _maxPosition.position.y);
       Debug.Log("X POSITION: " + xPosition +  " ; Y POSITION: " + yPosition);
       return new Vector2(xPosition ,yPosition);
   }
}
