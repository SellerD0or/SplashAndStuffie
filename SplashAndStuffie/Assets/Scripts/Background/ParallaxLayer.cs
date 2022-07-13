using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
     public float parallaxFactor;
     public Transform _startPosition, _endPosition;
       public void Move(float delta, Player player)
       {
           Vector3 newPos = transform.localPosition;
           newPos.x -= delta * parallaxFactor ;
           transform.localPosition = newPos;
       }
}
