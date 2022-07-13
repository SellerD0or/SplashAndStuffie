using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBullet : MonoBehaviour
{
  public abstract Player Player {get;set;}
    
    public abstract void SetPlayer(Player enemy);
}
