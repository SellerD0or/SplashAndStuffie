using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class EnemyBullet : MonoBehaviour
{
   
    public abstract Enemy Enemy {get;set;}
    
    public abstract void SetEnemy(Enemy enemy, Transform shotPosition);
}
