using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerCamera : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    private int _countOfElemetns;
       public void ShakeCamera()
    {
      _countOfElemetns = 0;
    }
    
}
