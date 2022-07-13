using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacterMoveableStar : MonoBehaviour
{
    [SerializeField] private Transform _startedPoint, _endedPoint;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _distance = 0.5f;
    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position,_endedPoint.position, _speed * Time.deltaTime);
        if (transform.position == _endedPoint.position)
        {
            transform.position= _startedPoint.position;
        }
    }
}
