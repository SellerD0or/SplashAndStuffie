using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomberAbilityFreeMode : AbilityFreeMode
{
    [SerializeField] private int _percentOfAdditionDamage = 220;
    public override void RemoveAbility()
    {
        Player.Damage = Player.Damage * 100 /  _percentOfAdditionDamage;

    }

    public override void UseAbility()
    {
         Player.Damage = Player.Damage * _percentOfAdditionDamage /100;
    }
}
