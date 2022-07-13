using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private List<SpawnerPosition> _spawnPositions;
    [SerializeField] private TakerDamageVisitor _visitor;
    [SerializeField] private GetterPlayer _getterPlayer;
    [SerializeField] private EnemyFire _enemyFire;
    [SerializeField] private CounterOfCharacterKills _counterOfCharacterKills;
    private void Start() 
    {
     SpawnEnemy();
     Destroy(gameObject);
    }
    private void SpawnEnemy() => _spawnPositions.ForEach(e => e.Spawn(_visitor,_getterPlayer,_enemyFire, _counterOfCharacterKills));
}
