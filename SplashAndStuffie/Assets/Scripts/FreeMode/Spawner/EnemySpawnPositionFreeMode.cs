using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPositionFreeMode : MonoBehaviour
{
   [SerializeField] private List<EnemyInformationFreeMode> _enemies;
   [SerializeField] private Vector2 _direction;
    public List<EnemyInformationFreeMode> Enemies { get => _enemies; set => _enemies = value; }
    public Vector2 Direction { get => _direction; set => _direction = value; }
    public PlaceRowFreeMode PlaceRow { get => _placeRow; set => _placeRow = value; }

    [SerializeField] private PlaceRowFreeMode _placeRow;
    public EnemyInformationFreeMode GetRandomEnemy()
    {
         return _enemies[Random.Range(0, Enemies.Count)];

    }
}
