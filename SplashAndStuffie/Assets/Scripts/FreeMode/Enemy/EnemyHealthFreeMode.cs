using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthFreeMode : MonoBehaviour
{
   [SerializeField]  private EnemyFire _enemyFire;
     public PlaceRowFreeMode PlaceRow { get; set; }
  [SerializeField] private EnemyInformationFreeMode _enemyInformation;
  public event UnityAction OnApplyDamage;
  public EnemySpawnerFreeMode EnemySpawner { get; set; }
  private void Start() {
      OnApplyDamage += ApplyDamage;
      _enemyInformation.OnDeath += Destroy;
  }
  public void TakeDamage(int damage)
  {
      Debug.Log(damage + " enemy applies damage!");
      
    //  if(_enemyInformation.Health > 0)
    // {
      _enemyInformation.Health -= damage;
      OnApplyDamage?.Invoke();
    //   if(_enemyInformation.Health <= 0)
   //   {
         
    //      _enemyInformation.Destroy();
     //     return;
     // }
    // }
    //      if(_enemyInformation.Health <= 0)
     // {
         
        //  _enemyInformation.Destroy();
          
    //  }
     // }
   

  }
  private void ApplyDamage()
  {
        if(_enemyInformation.Health <= 0)
      {
          Debug.Log("Destroy enemy");
          _enemyInformation.Destroy();
      }
  }
  private void Destroy()
  {
     // Instantiate(_enemyFire,transform.position,)
     EnemySpawner.Remove();
      Debug.Log("DIE " + name);
      PlaceRow.RemoveEnemy(_enemyInformation);
      Destroy(gameObject);
  }
}
