using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakerDamageVisitor : MonoBehaviour, IVisitor
{
  //  public void Visit(Slime slime)
    //{
  //     slime.PlayerHealth.TakeDamage(slime.Enemy.Damage);
    //    Debug.Log(slime.PlayerHealth.Health);
    //}

//    public void Visit(Warrior warrior) 
//    {
      //  warrior.Player.PlayerHealth.TakeDamage(warrior.Damage);
  //      Debug.Log(warrior.Player.PlayerHealth.Health);
    //}

 //   public void Visit(Ranger ranger)
  //  {
      //  ranger.Player.PlayerHealth.TakeDamage(ranger.Damage);
  //      Debug.Log(ranger.Player.PlayerHealth.Health);
  //  }

    public void Visit(Player player)
    {
       // player.Enemy.EnemyHealth.TakeDamage(2);
    }

    public void Visit(Enemy enemy)
    {
     // Player player = FindObjectOfType<Player>();
        enemy.Player.PlayerHealth.TakeDamage(enemy.Damage);
       // throw new System.NotImplementedException();
    }
}