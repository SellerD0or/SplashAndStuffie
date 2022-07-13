using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterOfCharacterKills : MonoBehaviour
{
  [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
   public event UnityAction OnKill;
   [SerializeField] private CompletetedLevelScreen _completedLevelScreen;
   [SerializeField] private int _coin;
   public void AddEnemy(Enemy enemy)
   {
    _enemies.Add(enemy);   
   }
   public void RemoveEnemy(Enemy enemy) 
   {  
        _coin++;
        _completedLevelScreen.Count = _coin;
        _enemies.Remove(enemy);
        if (_enemies.Count <= 0)
        {
            _completedLevelScreen.gameObject.SetActive(true);
            _completedLevelScreen.Win(enemy.Player);
        } 
   }
}
