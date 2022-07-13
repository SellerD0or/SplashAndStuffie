using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShamanShadow : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 5f;
    private void Start() {
        Destroy(gameObject, _destroyTime);
    }
}
