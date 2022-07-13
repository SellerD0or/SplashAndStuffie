using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3DSpawnPosition : MonoBehaviour
{
 [SerializeField] private Enemy[] _enemies;
 public void CreateEnemy()
 {
     int random = Random.Range(0, _enemies.Length);
     Instantiate(_enemies[random],transform.position,Quaternion.identity);
 }
}
