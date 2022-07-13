using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyOutPut
{
    Enemy Enemy {get;set;}
    void ShowEnemyHealth();
}
