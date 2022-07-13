using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFreeMode : MonoBehaviour
{
   [SerializeField] private List< EnemyInformationFreeMode> _lastEnemies;
    public List<EnemyInformationFreeMode> AllEnemies { get; set; } = new List<EnemyInformationFreeMode>();
    [SerializeField] private List< EnemyInformationFreeMode> _enemies;
    public List<EnemyInformationFreeMode> Enemies { get => _enemies; set => _enemies = value; }
    public int CountOfEnemies { get; set; }
    public int CurrentCountOfEnemies { get; set; }
    public List<EnemyInformationFreeMode> LastEnemies { get => _lastEnemies; set => _lastEnemies = value; }

    private void Start() {
        foreach (var item in Enemies)
        {
            AllEnemies.Add(item);
        }
        CountOfEnemies = AllEnemies.Count;
        CurrentCountOfEnemies = AllEnemies.Count;
    }
}
