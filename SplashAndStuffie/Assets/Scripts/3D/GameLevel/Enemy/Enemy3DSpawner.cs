using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3DSpawner : MonoBehaviour
{
   [SerializeField] private List<Enemy3DSpawnPosition> _enemySpawners;
   private void Start() {
       CreateEnemy();
   }
   public void CreateEnemy()
   {
       foreach (var item in _enemySpawners)
       {
           item.CreateEnemy();
       }
   }
}
